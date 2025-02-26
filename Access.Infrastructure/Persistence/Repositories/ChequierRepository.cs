using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ChequierRepository(ColiZenDbContext dbContext)
      : Repository<Chequier, int>(dbContext), IChequierRepository
    {
    }
}
