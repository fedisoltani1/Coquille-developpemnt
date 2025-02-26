using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistances;
using Access.AppCore.Interfaces.Persistence;
using Access.AppCore.Interfaces.Persistence.Services;
using Access.AppCore.Models;
using Access.AppCore.Models.Ville;
using Access.AppCore.Validator;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Access.AppCore.Services
{
    public class VilleService(IRepository<Ville, int> villeRepository,
           IUnitOfWork unitOfWork,
           IMapper mapper,
           ILogger<VilleService> logger,
           VilleValidator validator) : IVilleService
    {
        public async Task<List<VilleModel>> ObtenirToutesLesVilles()
        {
            try
            {
                var Liste = await villeRepository.ToListAsync(
                    q => q.Include(v => v.Gouvernorat),
                    q => q.Include(v => v.Cites),
                    q => q.Include(v => v.ZoneVilles)
                );

                var ville = mapper.Map<List<VilleModel>>(Liste);
                logger.LogInformation("Récupération réussie : {Count} villes trouvées.", ville.Count);
                return ville;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la récupération des villes.");
               throw;
            }
        }

        public async Task<Resultat<VilleModel>> ObtenirVilleParId(int id)
        {
            try
            {
                var ville = await villeRepository.FirstOrDefaultAsync(
                    v => v.Id == id,
                    q => q.Include(v => v.Cites),
                    q => q.Include(v => v.ZoneVilles),
                    q => q.Include(v => v.Gouvernorat)
                );

                if (ville == null)
                {
                    logger.LogWarning("Ville avec l'ID {Id} non trouvée.", id);
                    return Resultat<VilleModel>.Fail(new Message($"Ville avec l'ID {id} non trouvée"));
                }

                var result = mapper.Map<VilleModel>(ville);
                logger.LogInformation("Ville avec l'ID {Id} récupérée avec succès.", id);
                return Resultat<VilleModel>.Success(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la récupération de la ville avec l'ID {Id}.", id);
                return Resultat<VilleModel>.Fail(new Message("Erreur lors de la récupération de la ville"));
            }
        }

        public async Task<Resultat> CreerVille(VilleModel villeModel)
        {
            var validationResult = await validator.ValidateAsync(villeModel);
            if (!validationResult.IsValid)
            {
                var messages = validationResult.Errors
                    .Select(e => new Message(e.ErrorMessage))
                    .ToArray();
                logger.LogWarning("Échec de la validation pour la création de la ville : {Errors}", string.Join(", ", messages.Select(m => m.Contenu)));
                return Resultat.Fail(messages);
            }

            try
            {
                var villeEntity = mapper.Map<Ville>(villeModel);
                villeRepository.Creer(villeEntity);
                var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();

                if (resultatSauvegarde.Echec)
                {
                    logger.LogError("Erreur lors de la sauvegarde : {Erreur}", resultatSauvegarde.Messages.Select(m => m.Contenu));
                    logger.LogError("Erreur lors de la création de la ville.");
                    return resultatSauvegarde;
                }

                logger.LogInformation("Ville ajoutée avec succès avec l'ID {Id}.", villeEntity.Id);
                return Resultat.Success();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur inattendue lors de la création de la ville.");
                return Resultat.Fail(new Message("Erreur inattendue lors de la création de la ville"));
            }
        }

        public async Task<Resultat> ModifierVille(VilleModel villeModel)
        {
            var validationResult = await validator.ValidateAsync(villeModel);
            if (!validationResult.IsValid)
            {
                var messages = validationResult.Errors
                    .Select(e => new Message(e.ErrorMessage))
                    .ToArray();

                logger.LogWarning("Échec de la validation pour la modification de la ville : {Errors}",
                    string.Join(", ", messages.Select(m => m.Contenu)));
                return Resultat.Fail(messages);
            }

            try
            {
                var existingVille = await villeRepository.FirstOrDefaultAsync(
                    v => v.Id == villeModel.Id,
                    q => q.Include(v => v.Cites),
                    q => q.Include(v => v.ZoneVilles),
                    q => q.Include(v => v.Gouvernorat)
                );

                if (existingVille == null)
                {
                    logger.LogWarning("Ville avec l'ID {Id} non trouvée pour modification.", villeModel.Id);
                    return Resultat.Fail(new Message($"Ville avec l'ID {villeModel.Id} non trouvée"));
                }

                villeRepository.Detacher(existingVille);
                mapper.Map(villeModel, existingVille);
                villeRepository.Modifier(existingVille);
                var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();
                if (resultatSauvegarde.Echec)
                {
                    logger.LogError("Erreur lors de la sauvegarde : {Erreur}",
                        resultatSauvegarde.Messages.Select(m => m.Contenu));
                    logger.LogError("Erreur lors de la modification de la ville avec l'ID {Id}.", villeModel.Id);
                    return resultatSauvegarde;
                }

                logger.LogInformation("Ville avec l'ID {Id} modifiée avec succès.", villeModel.Id);
                return Resultat.Success();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur inattendue lors de la modification de la ville avec l'ID {Id}.", villeModel.Id);
                return Resultat.Fail(new Message("Erreur inattendue lors de la modification de la ville"));
            }
        }


        public async Task<Resultat> SupprimerVille(int id)
        {
            try
            {
                var ville = await villeRepository.FirstOrDefaultAsync(v => v.Id == id);

                if (ville == null)
                {
                    logger.LogWarning("Ville avec l'ID {Id} non trouvée pour suppression.", id);
                    return Resultat.Fail(new Message($"Ville avec l'ID {id} non trouvée"));
                }
                villeRepository.Supprimer(ville);

                var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();
                if (resultatSauvegarde.Echec)
                {
                    logger.LogError("Erreur lors de la sauvegarde : {Erreur}", resultatSauvegarde.Messages.Select(m => m.Contenu));
                    return resultatSauvegarde;
                }

                logger.LogInformation("Ville avec l'ID {Id} supprimée avec succès.", id);
                return Resultat.Success();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Erreur lors de la suppression de la ville avec l'ID {Id}.", id);
                if (ex.InnerException is SqlException sqlEx)
                {
                    return Resultat.Fail(new Message("Impossible de supprimer . Ville utilisée."));
                }
                return Resultat.Fail(new Message("Erreur lors de la suppression de la ville."));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur inattendue lors de la suppression de la ville avec l'ID {Id}.", id);
                return Resultat.Fail(new Message("Erreur inattendue lors de la suppression de la ville."));
            }
        }


    }
}
