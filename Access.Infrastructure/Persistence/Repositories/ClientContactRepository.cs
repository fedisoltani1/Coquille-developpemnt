using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ClientContactRepository(ColiZenDbContext dbContext)
      : Repository<ClientContact, int>(dbContext), IClientContactRepository
    {
    }
}
