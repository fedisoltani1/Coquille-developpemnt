using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class FacturationCategoryRepository(ColiZenDbContext dbContext)
      : Repository<FacturationCategory, int>(dbContext), IFacturationCategoryRepository
    {
    }
}
