using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ModesReglementFacturationRepository(ColiZenDbContext dbContext)
      : Repository<ModesReglementFacturation, int>(dbContext), IModesReglementFacturationRepository
    {
    }
}
