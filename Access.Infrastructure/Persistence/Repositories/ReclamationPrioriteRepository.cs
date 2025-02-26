using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ReclamationPrioriteRepository(ColiZenDbContext dbContext)
      : Repository<ReclamationPriorite, int>(dbContext), IReclamationPrioriteRepository
    {
    }
}
