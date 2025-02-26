using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ServiceRepository(ColiZenDbContext dbContext)
      : Repository<Service, int>(dbContext), IServiceRepository
    {
    }
}
