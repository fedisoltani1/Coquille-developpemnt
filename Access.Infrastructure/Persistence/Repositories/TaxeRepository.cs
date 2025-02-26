using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class TaxeRepository(ColiZenDbContext dbContext)
      : Repository<Taxe, int>(dbContext), ITaxeRepository
    {
    }
}
