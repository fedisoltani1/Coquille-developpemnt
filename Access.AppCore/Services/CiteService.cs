using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistances;
using Access.AppCore.Interfaces.Persistence;
using Access.AppCore.Interfaces.Persistence.Services;
using Access.AppCore.Models;
using Access.AppCore.Models.Cite;
using Access.AppCore.Validator;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Access.AppCore.Services
{
    public class CiteService(IRepository<Cite, int> citeRepository,
           IUnitOfWork unitOfWork,
           IMapper mapper,
           ILogger<CiteService> logger,
           CiteValidator validator) : ICiteService
    {
        public async Task<List<CiteModel>> ObtenirToutesLesCites()
        {
            try
            {
                var liste = await citeRepository.ToListAsync(
                    q => q.Include(c => c.Ville),
                    q => q.Include(c => c.Gouvernorat),
                    q => q.Include(c => c.ZoneVilles)
                );

                var cites = mapper.Map<List<CiteModel>>(liste);
                logger.LogInformation("Récupération réussie : {Count} cités trouvées.", cites.Count);
                return cites;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la récupération des cités.");
                throw;
            }
        }

        public async Task<Resultat<CiteModel>> ObtenirCiteParId(int id)
        {
            try
            {
                var cite = await citeRepository.FirstOrDefaultAsync(
                    c => c.Id == id,
                    q => q.Include(c => c.Gouvernorat),
                    q => q.Include(c => c.Ville),
                    q => q.Include(c => c.ZoneVilles)
                );

                if (cite == null)
                {
                    logger.LogWarning("Cite avec l'ID {Id} non trouvée.", id);
                    return Resultat<CiteModel>.Fail(new Message($"Cite avec l'ID {id} non trouvée"));
                }

                var result = mapper.Map<CiteModel>(cite);
                logger.LogInformation("Cite avec l'ID {Id} récupérée avec succès.", id);
                return Resultat<CiteModel>.Success(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la récupération de la cite avec l'ID {Id}.", id);
                return Resultat<CiteModel>.Fail(new Message("Erreur lors de la récupération de la cite"));
            }
        }

        public async Task<Resultat> AjouterCite(CiteModel citeModel)
        {
            ArgumentNullException.ThrowIfNull(citeModel);
            var validationResult = await validator.ValidateAsync(citeModel);
            if (!validationResult.IsValid)
            {
                var messages = validationResult.Errors
                    .Select(e => new Message(e.ErrorMessage))
                    .ToArray();
                logger.LogWarning("Échec de la validation pour la création de la cite : {Errors}", string.Join(", ", messages.Select(m => m.Contenu)));
                return Resultat.Fail(messages);
            }

            try
            {
                var citeEntity = mapper.Map<Cite>(citeModel);
                citeRepository.Creer(citeEntity);

                var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();
                if (resultatSauvegarde.Echec)
                {
                    logger.LogError("Erreur lors de la sauvegarde : {Erreur}", string.Join(", ", resultatSauvegarde.Messages.Select(m => m.Contenu)));
                    return resultatSauvegarde;
                }

                logger.LogInformation("Cite ajoutée avec succès avec l'ID {Id}.", citeEntity.Id);
                return Resultat.Success();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur inattendue lors de la création de la cite.");
                return Resultat.Fail(new Message("Erreur inattendue lors de la création de la cite."));
            }
        }

        public async Task<Resultat> ModifierCite(CiteModel citeModel)
        {
            // Validate the model
            var validationResult = await validator.ValidateAsync(citeModel);
            if (!validationResult.IsValid)
            {
                var messages = validationResult.Errors
                    .Select(e => new Message(e.ErrorMessage))
                    .ToArray();

                logger.LogWarning("Échec de la validation pour la modification de la cite : {Errors}",
                    string.Join(", ", messages.Select(m => m.Contenu)));
                return Resultat.Fail(messages);
            }

            try
            {
                var existingCite = await citeRepository.FirstOrDefaultAsync(
                    c => c.Id == citeModel.Id,
                    q => q.Include(c => c.Gouvernorat),
                    q => q.Include(c => c.Ville)
                    );

                if (existingCite == null)
                {
                    logger.LogWarning("Cite avec l'ID {Id} non trouvée pour modification.", citeModel.Id);
                    return Resultat.Fail(new Message($"Cite avec l'ID {citeModel.Id} non trouvée."));
                }

                citeRepository.Detacher(existingCite);
                mapper.Map(citeModel, existingCite);

                citeRepository.Modifier(existingCite);
                var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();
                if (resultatSauvegarde.Echec)
                {
                    logger.LogError("Erreur lors de la sauvegarde : {Erreur}",
                        string.Join(", ", resultatSauvegarde.Messages.Select(m => m.Contenu)));
                    return resultatSauvegarde;
                }

                logger.LogInformation("Cite avec l'ID {Id} modifiée avec succès.", citeModel.Id);
                return Resultat.Success();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur inattendue lors de la modification de la cite avec l'ID {Id}.", citeModel.Id);
                return Resultat.Fail(new Message("Erreur inattendue lors de la modification de la cite."));
            }
        }



        public async Task<Resultat> SupprimerCite(int citeId)
        {
            try
            {
                var existingCite = await citeRepository.FirstOrDefaultAsync(c => c.Id == citeId);

                if (existingCite == null)
                {
                    logger.LogWarning("Cite avec l'ID {Id} non trouvée pour suppression.", citeId);
                    return Resultat.Fail(new Message($"Cite avec l'ID {citeId} non trouvée."));
                }

                citeRepository.Supprimer(existingCite);

                var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();
                if (resultatSauvegarde.Echec)
                {
                    logger.LogError("Erreur lors de la sauvegarde après la suppression : {Erreur}",
                        string.Join(", ", resultatSauvegarde.Messages.Select(m => m.Contenu)));
                    return resultatSauvegarde;
                }

                logger.LogInformation("Cite avec l'ID {Id} supprimée avec succès.", citeId);
                return Resultat.Success();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Erreur lors de la suppression de la cite avec l'ID {Id}.", citeId);
                if (ex.InnerException is SqlException sqlEx)
                {
                    return Resultat.Fail(new Message("Impossible de supprimer . la cite est utilisée ."));
                }
                return Resultat.Fail(new Message("Erreur lors de la suppression de la cite."));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur inattendue lors de la suppression de la cite avec l'ID {Id}.", citeId);
                return Resultat.Fail(new Message("Erreur inattendue lors de la suppression de la cite."));
            }
        }

    }
}
