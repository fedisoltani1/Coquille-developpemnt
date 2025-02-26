using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ClientWarehouseRepository(ColiZenDbContext dbContext)
      : Repository<ClientWarehouse, int>(dbContext), IClientWarehouseRepository
    {
    }
}
