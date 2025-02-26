using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class FactureRepository(ColiZenDbContext dbContext)
      : Repository<Facture, int>(dbContext), IFactureRepository
    {
    }
}
