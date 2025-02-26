using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class GouvernoratRepository(ColiZenDbContext dbContext)
      : Repository<Gouvernorat, int>(dbContext), IGouvernoratRepository
    {
    }
}
