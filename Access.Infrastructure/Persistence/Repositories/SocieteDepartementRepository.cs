using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class SocieteDepartementRepository(ColiZenDbContext dbContext)
      : Repository<SocieteDepartement, int>(dbContext), ISocieteDepartementRepository
    {
    }
}
