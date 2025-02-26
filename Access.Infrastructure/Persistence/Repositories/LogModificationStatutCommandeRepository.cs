using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class LogModificationStatutCommandeRepository(ColiZenDbContext dbContext)
      : Repository<LogModificationStatutCommande, int>(dbContext), ILogModificationStatutCommandeRepository
    {
    }
}
