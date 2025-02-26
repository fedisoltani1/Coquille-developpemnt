using Access.AppCore.Models;
using Access.AppCore.Models.Cite;

namespace Access.AppCore.Interfaces.Persistence.Services
{
    public interface ICiteService
    {
        Task<List<CiteModel>>ObtenirToutesLesCites();

        Task<Resultat<CiteModel>> ObtenirCiteParId(int id);

        Task<Resultat> AjouterCite(CiteModel citeModel);

        Task<Resultat> ModifierCite(CiteModel citeModel);

        Task<Resultat> SupprimerCite(int citeId);
    }
}
