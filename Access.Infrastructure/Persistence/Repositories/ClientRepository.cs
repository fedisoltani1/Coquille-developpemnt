using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ClientRepository(ColiZenDbContext dbContext)
      : Repository<Client, int>(dbContext), IClientRepository
    {
    }
}
