using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ProspectRepository(ColiZenDbContext dbContext)
      : Repository<Prospect, int>(dbContext), IProspectRepository
    {
    }
}
