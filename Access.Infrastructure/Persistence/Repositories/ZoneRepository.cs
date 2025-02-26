using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ZoneRepository(ColiZenDbContext dbContext)
      : Repository<Zone, int>(dbContext), IZoneRepository
    {
    }
}
