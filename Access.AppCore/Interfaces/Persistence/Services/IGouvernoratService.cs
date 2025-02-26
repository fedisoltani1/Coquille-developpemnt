using Access.AppCore.Models;
using Access.AppCore.Models.Gouvernorat;

namespace Access.AppCore.Interfaces.Persistence.Services
{
    public interface IGouvernoratService
    {
         Task<List<GouvernoratModel>> ObtenirTousLesGouvernorats();

         Task<Resultat<GouvernoratModel>> ObtenirGouvernorat(int id);

         Task<Resultat> AjouterGouvernorat(GouvernoratModel gouvernorat);

         Task<Resultat> ModifierGouvernorat(GouvernoratModel gouvernorat);

         Task<Resultat> SupprimerGouvernorat(int id);
    }
}
