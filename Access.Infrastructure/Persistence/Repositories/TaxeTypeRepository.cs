using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class TaxeTypeRepository(ColiZenDbContext dbContext)
      : Repository<TaxeType, int>(dbContext), ITaxeTypeRepository
    {
    }
}
