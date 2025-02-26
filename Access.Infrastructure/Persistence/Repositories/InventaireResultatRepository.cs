using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class InventaireResultatRepository(ColiZenDbContext dbContext)
      : Repository<InventaireResultat, int>(dbContext), IInventaireResultatRepository
    {
    }
}
