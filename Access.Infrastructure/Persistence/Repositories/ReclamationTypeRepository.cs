using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ReclamationTypeRepository(ColiZenDbContext dbContext)
      : Repository<ReclamationType, int>(dbContext), IReclamationTypeRepository
    {
    }
}
