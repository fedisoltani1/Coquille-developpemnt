using Access.AppCore.Models;
using Access.AppCore.Models.Societe;

namespace Access.AppCore.Interfaces.Persistence.Services
{
    public interface ISocieteService
    {
        Task<Resultat> ModifierSociete(SocieteModel societeModel);

        Task<Resultat<SocieteModel>> ObtenirSociete(int id);

        Task<List<SocieteModel>> ObtenirTousLesSociete();

        Task<SocieteModel> ObtenirSocieteCourante();

        Task<Resultat> SupprimerSociete(int id);
    }
}
