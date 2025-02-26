using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class InventaireScanRepository(ColiZenDbContext dbContext)
      : Repository<InventaireScan, int>(dbContext), IInventaireScanRepository
    {
    }
}
