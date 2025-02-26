using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class MotifsCallCenterRepository(ColiZenDbContext dbContext)
      : Repository<MotifsCallCenter, int>(dbContext), IMotifsCallCenterRepository
    {
    }
}
