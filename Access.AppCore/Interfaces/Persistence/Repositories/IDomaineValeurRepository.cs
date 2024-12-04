using Access.AppCore.Entities;

namespace Access.AppCore.Interfaces.Persistances.Repositories
{
    public interface IDomaineValeurRepository : IRepository<DomaineValeur, int>
    {
        IEnumerable<DomaineValeur> AutreMethodeObtenir();
    }
}