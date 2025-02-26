using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class SocieteAgenceRepository(ColiZenDbContext dbContext)
      : Repository<SocieteAgence, int>(dbContext), ISocieteAgenceRepository
    {
    }
}
