using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class InventaireStockTheoriqueRepository (ColiZenDbContext dbContext)
      : Repository<InventaireStockTheorique, int>(dbContext), IInventaireStockTheoriqueRepository
    {
    }
}
