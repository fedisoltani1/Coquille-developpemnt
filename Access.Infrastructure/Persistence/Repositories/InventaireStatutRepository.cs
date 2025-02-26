using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class InventaireStatutRepository(ColiZenDbContext dbContext)
      : Repository<InventaireStatut, int>(dbContext), IInventaireStatutRepository
    {
    }
}
