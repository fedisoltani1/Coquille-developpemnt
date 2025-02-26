using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ChequeRepository(ColiZenDbContext dbContext)
      : Repository<Cheque, int>(dbContext), IChequeRepository
    {
    }
}
