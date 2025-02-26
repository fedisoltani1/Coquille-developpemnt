using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class MotifsLivraisonRepository(ColiZenDbContext dbContext)
      : Repository<MotifsLivraison, int>(dbContext), IMotifsLivraisonRepository
    {
    }
}
