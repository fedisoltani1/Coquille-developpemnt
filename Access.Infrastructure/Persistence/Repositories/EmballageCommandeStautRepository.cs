using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class EmballageCommandeStautRepository(ColiZenDbContext dbContext)
      : Repository<EmballageCommandeStaut, int>(dbContext), IEmballageCommandeStautRepository
    {
    }
}
