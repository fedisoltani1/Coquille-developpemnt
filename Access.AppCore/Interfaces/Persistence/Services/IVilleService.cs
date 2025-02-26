using Access.AppCore.Models;
using Access.AppCore.Models.Ville;

namespace Access.AppCore.Interfaces.Persistence.Services
{
    public interface IVilleService
    {
        Task<List<VilleModel>> ObtenirToutesLesVilles();

        Task<Resultat<VilleModel>> ObtenirVilleParId(int id);

        Task<Resultat> CreerVille(VilleModel villeModel);

        Task<Resultat> ModifierVille(VilleModel villeModel);

        Task<Resultat> SupprimerVille(int id);
    }
}
