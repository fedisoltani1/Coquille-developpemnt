using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistances;
using Access.AppCore.Interfaces.Persistence;
using Access.AppCore.Interfaces.Persistence.Services;
using Access.AppCore.Models;
using Access.AppCore.Models.Gouvernorat;
using Access.AppCore.Validator;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Access.AppCore.Models.Ville;

namespace Access.AppCore.Services
{
    public class GouvernoratService(IRepository<Gouvernorat, int> gouvernoratRepository,
           IUnitOfWork unitOfWork,
           IMapper mapper,
           ILogger<GouvernoratService> logger,
           GouvernoratValidator validator) : IGouvernoratService
    {
        public async Task<List<GouvernoratModel>> ObtenirTousLesGouvernorats()
        {
            try
            {
                var liste = await gouvernoratRepository.ToListAsync(
                    q => q.Include(c => c.Cites),
                    q => q.Include(c => c.Villes),
                    q => q.Include(c => c.ZoneVilles)
                );
                var gouvernorats = mapper.Map<List<GouvernoratModel>>(liste);

                logger.LogInformation("Récupération réussie : {Count} Gouvernorats trouvés.", gouvernorats.Count);

                return gouvernorats;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la récupération des Gouvernorats.");

                throw;
            }
        }

        public async Task<Resultat<GouvernoratModel>> ObtenirGouvernorat(int id)
        {
            try
            {
                var gouvernorat = await gouvernoratRepository
                          .FirstOrDefaultAsync(
                    c => c.Id == id,
                    q => q.Include(c => c.Cites),
                    q => q.Include(c => c.Villes),
                    q => q.Include(c => c.ZoneVilles)
                );
                if (gouvernorat == null)
                {
                    return Resultat<GouvernoratModel>.Fail(new Message("Gouvernorats non trouvée"));
                }

                logger.LogInformation("Gouvernorat récupérée avec succès. ID: {id}", id);

                return Resultat<GouvernoratModel>.Success(mapper.Map<GouvernoratModel>(gouvernorat));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la récupération du Gouvernorat.");
                throw;
            }
        }

        public async Task<Resultat> AjouterGouvernorat(GouvernoratModel gouvernorat)
        {
            ArgumentNullException.ThrowIfNull(nameof(gouvernorat));
            var resultatValidation = validator.Validate(gouvernorat);
            if (!resultatValidation.IsValid)
            {
                var messages = resultatValidation.Errors
                    .Select(e => new Message(e.ErrorMessage))
                    .ToArray();
                return Resultat.Fail(messages);
            }

            var codeExiste = await gouvernoratRepository.ExistAsync(x => x.Code == gouvernorat.Code);
            if (codeExiste)
            {
                return Resultat.Fail(new Message("Le code du gouvernorat existe déjà."));
            }

            var gouvernoratEntity = mapper.Map<Gouvernorat>(gouvernorat);
            gouvernoratRepository.Creer(gouvernoratEntity);

            var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();

            if (resultatSauvegarde.Echec)
            {
                logger.LogError("Erreur lors de la sauvegarde du gouvernorat : {Erreur}", resultatSauvegarde.Messages);
                return Resultat.Fail(new Message("Erreur lors de l'ajout du gouvernorat."));
            }

            logger.LogInformation("Gouvernorat ajouté avec succès.");
            return Resultat.Success();
        }

        public async Task<Resultat> ModifierGouvernorat(GouvernoratModel gouvernorat)
        {
            ArgumentNullException.ThrowIfNull(nameof(gouvernorat));
            var resultatValidation = validator.Validate(gouvernorat);
            if (!resultatValidation.IsValid)
            {
                var messages = resultatValidation.Errors
                    .Select(e => new Message(e.ErrorMessage))
                    .ToArray();
                return Resultat.Fail(messages);
            }

            var gouvernoratExistant = await gouvernoratRepository.FirstOrDefaultAsync(
                x => x.Id == gouvernorat.Id,
                q => q.Include(c => c.Cites),
                q => q.Include(c => c.Villes),
                q => q.Include(c => c.ZoneVilles)
                );
            if (gouvernoratExistant == null)
            {
                return Resultat.Fail(new Message("Le gouvernorat spécifié n'existe pas."));
            }

            gouvernoratRepository.Detacher(gouvernoratExistant);
            mapper.Map(gouvernorat, gouvernoratExistant);

            gouvernoratRepository.Modifier(gouvernoratExistant);
            var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();

            if (resultatSauvegarde.Echec)
            {
                logger.LogError("Erreur lors de la modification du gouvernorat : {Erreur}", resultatSauvegarde.Messages);
                return resultatSauvegarde;
            }

            logger.LogInformation("Gouvernorat modifié avec succès.");
            return Resultat.Success();
        }

        public async Task<Resultat> SupprimerGouvernorat(int id)
        {
            try
            {
                var gouvernorat = await gouvernoratRepository.FirstOrDefaultAsync(x => x.Id == id);

                if (gouvernorat == null)
                {
                    return Resultat.Fail(new Message("Gouvernorat non trouvé"));
                }

                gouvernoratRepository.Supprimer(gouvernorat);

                var resultatSauvegarde = await unitOfWork.SauvegarderResultatAsync();
                if (resultatSauvegarde.Echec)
                {
                    return resultatSauvegarde;
                }

                logger.LogInformation("Gouvernorat supprimé avec succès. ID: {Id}", id);
                return Resultat.Success();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Erreur lors de la suppression du gouvernorat. ID: {Id}", id);
                if (ex.InnerException is SqlException sqlEx)
                {
                    return Resultat.Fail(new Message("Impossible de supprimer. Gouvernorat utilisé"));
                }
                return Resultat.Fail(new Message("Erreur lors de la suppression du gouvernorat."));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur inattendue lors de la suppression du gouvernorat. ID: {Id}", id);
                return Resultat.Fail(new Message("Erreur inattendue lors de la suppression du gouvernorat."));
            }
        }

    }
}
