using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class CommandeCategoryRepository(ColiZenDbContext dbContext)
      : Repository<CommandeCategory, int>(dbContext), ICommandeCategoryRepository
    {
    }
}
