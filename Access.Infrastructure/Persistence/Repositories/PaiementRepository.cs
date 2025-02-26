using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class PaiementRepository(ColiZenDbContext dbContext)
      : Repository<Paiement, int>(dbContext), IPaiementRepository
    {
    }
}
