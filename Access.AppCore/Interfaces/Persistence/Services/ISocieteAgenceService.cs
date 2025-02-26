using Access.AppCore.Models;
using Access.AppCore.Models.SocieteAgence;

namespace Access.AppCore.Interfaces.Persistence.Services
{
    public interface ISocieteAgenceService
    {
        Task<List<SocieteAgenceModel>> ObtenirTousLesSocieteAgence();

        Task<Resultat<SocieteAgenceModel>> ObtenirSocieteAgence(int id);

        Task<Resultat> AjouterSocieteAgence(SocieteAgenceModel societeAgence);

        Task<Resultat> ModifierSocieteAgence(SocieteAgenceModel societeAgence);

        Task<Resultat> SupprimerSocieteAgence(int id);

    }
}
