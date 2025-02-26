using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ChequeStatutRepository(ColiZenDbContext dbContext)
      : Repository<ChequeStatut, int>(dbContext), IChequeStatutRepository
    {
    }
}
