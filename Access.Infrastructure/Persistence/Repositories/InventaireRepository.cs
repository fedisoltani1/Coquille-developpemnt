using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class InventaireRepository(ColiZenDbContext dbContext)
      : Repository<Inventaire, int>(dbContext), IInventaireRepository
    {
    }
}
