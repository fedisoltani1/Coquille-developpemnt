using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistances;
using Access.AppCore.Interfaces.Persistence;
using Access.AppCore.Interfaces.Persistence.Services;
using Access.AppCore.Models;
using Access.AppCore.Models.Societe;
using Access.AppCore.Validators;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Access.AppCore.Services
{
    public class SocieteService(IRepository<Societe, int> societeRepository,
           IUnitOfWork unitOfWork,
           IMapper mapper,
           ILogger<SocieteService> logger,
           SocieteValidator validator) : ISocieteService
    {
        public async Task<SocieteModel> ObtenirSocieteCourante()
        {
            try
            {
                var societe = await societeRepository.FirstAsync();
                if (societe == null)
                {
                    logger.LogWarning("Aucune société trouvée.");
                    return null;
                }

                var societeModel = mapper.Map<Societe, SocieteModel>(societe);
                logger.LogInformation("Récupération réussie pour la société avec ID {Id}.", societeModel.Id);

                return societeModel;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la récupération de la société courante.");
                throw;
            }
        }

        public async Task<List<SocieteModel>> ObtenirTousLesSociete()
        {
            try
            {
                var liste = await societeRepository.ToListAsync();
                var societes = mapper.Map<List<Societe>, List<SocieteModel>>(liste);

                logger.LogInformation("Récupération réussie : {Count} sociétés trouvées.", societes.Count);

                return societes;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la récupération des sociétés.");
                throw;
            }
        }

        public async Task<Resultat<SocieteModel>> ObtenirSociete(int id)
        {
            try
            {
                var societe = await societeRepository.FirstOrDefaultAsync(s => s.Id == id);
                if (societe == null)
                {
                    return Resultat<SocieteModel>.Fail(new Message ( "Société non trouvée" ));
                }

                logger.LogInformation("Société récupérée avec succès. ID: {id}", id);
                return Resultat<SocieteModel>.Success(mapper.Map<Societe, SocieteModel>(societe));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la récupération de la société.");
                throw;
            }
        }

        public async Task<Resultat> ModifierSociete(SocieteModel societeModel)
        {
            ArgumentNullException.ThrowIfNull(societeModel);
            var resultatValidation = validator.Validate(societeModel);
            if (!resultatValidation.IsValid)
            {
                var messages = resultatValidation.Errors
                    .Select(e => new Message(e.ErrorMessage))
                    .ToArray();

                logger.LogWarning("Erreur de validation pour la société. Messages : {Messages}", string.Join(", ", messages.Select(m => m.Contenu)));
                return Resultat.Fail(messages);
            }

            var societeExistante = await societeRepository.FirstOrDefaultAsync(
                     x => x.Id == societeModel.Id
                   );

            if (societeExistante == null)
            {
                logger.LogWarning("Société avec ID {Id} non trouvée.", societeModel.Id);
                return Resultat.Fail(new Message("Société non trouvée"));
            }

            mapper.Map(societeModel, societeExistante);

            societeRepository.Modifier(societeExistante);
            var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();
            if (resultatSauvegarde.Echec)
            {
                logger.LogError("Erreur lors de la sauvegarde de la société.");
                return resultatSauvegarde;
            }

            logger.LogInformation("Société modifiée avec succès. ID : {Id}", societeModel.Id);
            return Resultat.Success();
        }

        public async Task<Resultat> SupprimerSociete(int id)
        {
            try
            {
                var entiteRepo = await societeRepository.FirstOrDefaultAsync(x => x.Id == id);

                if (entiteRepo == null)
                {
                    logger.LogWarning("Société avec ID {Id} non trouvée pour suppression.", id);
                    return Resultat.Fail(new Message("Société non trouvée"));
                }

                // Supprimer l'entité
                societeRepository.Supprimer(entiteRepo);

                var resultat = await unitOfWork.SauvegarderResultatAsync();
                if (resultat.Echec)
                {
                    logger.LogError("Erreur lors de la suppression de la société avec ID {Id}.", id);
                    return resultat;
                }

                logger.LogInformation("Société avec ID {Id} supprimée avec succès.", id);
                return Resultat.Success();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Erreur lors de la suppression de la société avec ID {Id}.", id);
                if (ex.InnerException is SqlException sqlEx)
                {
                    return Resultat.Fail(new Message("Impossible de supprimer. Société utilisée."));
                }
                return Resultat.Fail(new Message("Erreur lors de la suppression de la société."));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur inattendue lors de la suppression de la société avec ID {Id}.", id);
                return Resultat.Fail(new Message("Erreur inattendue lors de la suppression de la société."));
            }
        }

    }
}
