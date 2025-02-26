using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class CiteRepository(ColiZenDbContext dbContext)
      : Repository<Cite, int>(dbContext), ICiteRepository
    {
    }
}
