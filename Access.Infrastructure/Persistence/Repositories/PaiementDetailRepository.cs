using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class PaiementDetailRepository(ColiZenDbContext dbContext)
      : Repository<PaiementDetail, int>(dbContext), IPaiementDetailRepository
    {
    }
}
