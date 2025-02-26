using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;
using Console = Access.AppCore.Entities.Console;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ConsoleRepository(ColiZenDbContext dbContext)
      : Repository<Console, int>(dbContext), IConsoleRepository
    {
    }
}
