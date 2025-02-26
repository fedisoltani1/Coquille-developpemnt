using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class BanqueRepository(ColiZenDbContext dbContext)
      : Repository<Banque, int>(dbContext), IBanqueRepository
    {
    }
}
