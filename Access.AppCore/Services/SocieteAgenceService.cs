using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistances;
using Access.AppCore.Interfaces.Persistence;
using Access.AppCore.Interfaces.Persistence.Services;
using Access.AppCore.Models;
using Access.AppCore.Models.SocieteAgence;
using Access.AppCore.Validators;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Access.AppCore.Services
{
    public class SocieteAgenceService(IRepository<SocieteAgence, int> societeAgenceRepository,
           IUnitOfWork unitOfWork,
           IMapper mapper,
           ILogger<SocieteAgenceService> logger,
           SocieteAgenceValidator validator) : ISocieteAgenceService
    {

        public async Task<List<SocieteAgenceModel>> ObtenirTousLesSocieteAgence()
        {
            try
            {
                var liste = await societeAgenceRepository.ToListAsync();
                var agences = mapper.Map<List<SocieteAgenceModel>>(liste);

                logger.LogInformation("Récupération réussie : {Count} Agences trouvées.", agences.Count);

                return agences;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la récupération des Agences.");
                throw;
            }
        }

        public async Task<Resultat<SocieteAgenceModel>> ObtenirSocieteAgence(int id)
        {
            try
            {
                var agence = await societeAgenceRepository
                          .FirstOrDefaultAsync(x => x.Id == id);
                if (agence == null)
                {
                    return Resultat<SocieteAgenceModel>.Fail(new Message("Société non trouvée"));
                }

                logger.LogInformation("Agence récupérée avec succès. ID: {id}", id);

                return Resultat<SocieteAgenceModel>.Success(mapper.Map<SocieteAgenceModel>(agence));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la récupération de la agenes.");
                throw;
            }
        }

        public async Task<Resultat> AjouterSocieteAgence(SocieteAgenceModel societeAgence)
        {
            ArgumentNullException.ThrowIfNull(societeAgence);
            var resultatValidation = validator.Validate(societeAgence);
            if (!resultatValidation.IsValid)
            {
                var messages = resultatValidation.Errors
                    .Select(e => new Message(e.ErrorMessage))
                    .ToArray();
                return Resultat.Fail(messages);
            }

            var nouvelleSocieteAgence = mapper.Map<SocieteAgence>(societeAgence);
            societeAgenceRepository.Creer(nouvelleSocieteAgence);
            var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();

            if (resultatSauvegarde.Echec)
            {
                logger.LogError("Erreur lors de la sauvegarde : {Erreur}", resultatSauvegarde.Messages);
                logger.LogError("Erreur lors de l'ajout de la société.");
                return resultatSauvegarde;
            }

            logger.LogInformation("Agence ajoutée avec succès.");
            return Resultat.Success();
        }

        public async Task<Resultat> ModifierSocieteAgence(SocieteAgenceModel societeAgence)
        {
            ArgumentNullException.ThrowIfNull(societeAgence);

            var resultatValidation = validator.Validate(societeAgence);
            if (!resultatValidation.IsValid)
            {
                var messages = resultatValidation.Errors
                    .Select(e => new Message(e.ErrorMessage))
                    .ToArray();
                return Resultat.Fail(messages);
            }

            var societeAgenceExistante = await societeAgenceRepository
               .FirstOrDefaultAsync(x => x.Id == societeAgence.Id);

            if (societeAgenceExistante == null)
            {
                return Resultat.Fail(new Message("Agence  non trouvée"));
            }

            mapper.Map(societeAgence, societeAgenceExistante);

            societeAgenceRepository.Modifier(societeAgenceExistante); 
            var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();
            if (resultatSauvegarde.Echec)
            {
                return resultatSauvegarde;
            }

            logger.LogInformation("Agence modifiée avec succès. ID: {Id}", societeAgence.Id);

            return Resultat.Success();
        }

        public async Task<Resultat> SupprimerSocieteAgence(int id)
        {
            try
            {
                var societeAgence = await societeAgenceRepository.FirstOrDefaultAsync(x => x.Id == id);

                if (societeAgence == null)
                {
                    return Resultat.Fail(new Message("Agence non trouvée"));
                }

                societeAgenceRepository.Supprimer(societeAgence);
                var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();
                if (resultatSauvegarde.Echec)
                {
                    return resultatSauvegarde;
                }

                logger.LogInformation("Agence supprimée avec succès. ID: {Id}", id);
                return Resultat.Success();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Erreur lors de la suppression de l'agence. ID: {Id}", id);
                if (ex.InnerException is SqlException sqlEx)
                {
                    return Resultat.Fail(new Message("Ligne utilisée. Suppression impossible !"));
                }
                return Resultat.Fail(new Message("Erreur lors de la suppression de l'agence"));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur inattendue lors de la suppression de l'agence. ID: {Id}", id);
                return Resultat.Fail(new Message("Erreur inattendue lors de la suppression de l'agence"));
            }
        }


    }
}
