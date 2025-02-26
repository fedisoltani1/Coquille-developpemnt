using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ModesReglementRepository(ColiZenDbContext dbContext)
      : Repository<ModesReglement, int>(dbContext), IModesReglementRepository
    {
    }
}
 