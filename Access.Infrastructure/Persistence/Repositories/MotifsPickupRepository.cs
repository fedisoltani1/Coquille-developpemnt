using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class MotifsPickupRepository(ColiZenDbContext dbContext)
      : Repository<MotifsPickup, int>(dbContext), IMotifsPickupRepository
    {
    }
}
