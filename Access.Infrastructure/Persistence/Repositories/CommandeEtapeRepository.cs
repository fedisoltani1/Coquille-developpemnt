using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class CommandeEtapeRepository(ColiZenDbContext dbContext)
      : Repository<CommandeEtape, int>(dbContext), ICommandeEtapeRepository
    {
    }
}
