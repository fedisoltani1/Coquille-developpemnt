using Access.AppCore.Models;
using Access.AppCore.Models.DomaineValeur;

namespace Access.AppCore.Interfaces.Persistances.Services
{
    public interface IDomaineValeurService
    {
        Task<List<DomaineValeurModel>> ObtenirAsync();

        Task<Resultat<DomaineValeurModel>> ObtenirAsync(int id);

        Task<Resultat<DomaineValeurModel>> ObtenirAvecCodeAsync(string code);

        Task<List<DomaineValeurModel>> ObtenirAsync(CriteresRechercheDomaineValeur criteresRecherche);

        Task<Resultat> AjouterAsync(DomaineValeurModel domaineValeur);

        Task<Resultat> ModifierAsync(DomaineValeurModel domaineValeur);

        Task<Resultat> SupprimerAsync(int id);
    }
}