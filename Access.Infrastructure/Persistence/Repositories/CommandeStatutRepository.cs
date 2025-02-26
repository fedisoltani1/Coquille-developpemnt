using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class CommandeStatutRepository(ColiZenDbContext dbContext)
      : Repository<CommandeStatut, int>(dbContext), ICommandeStatutRepository
    {
    }
}
