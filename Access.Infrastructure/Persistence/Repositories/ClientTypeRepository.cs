using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ClientTypeRepository(ColiZenDbContext dbContext)
      : Repository<ClientType, int>(dbContext), IClientTypeRepository
    {
    }
}
