using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ReclamationRepository(ColiZenDbContext dbContext)
      : Repository<Reclamation, int>(dbContext), IReclamationRepository
    {
    }
}
