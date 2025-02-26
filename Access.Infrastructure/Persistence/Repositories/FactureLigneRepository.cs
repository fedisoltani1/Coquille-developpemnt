using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class FactureLigneRepository(ColiZenDbContext dbContext)
      : Repository<FactureLigne, int>(dbContext), IFactureLigneRepository
    {
    }
}
