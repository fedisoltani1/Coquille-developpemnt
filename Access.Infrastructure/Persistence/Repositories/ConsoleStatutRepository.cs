using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ConsoleStatutRepository(ColiZenDbContext dbContext)
      : Repository<ConsoleStatut, int>(dbContext), IConsoleStatutRepository
    {
    }
}
