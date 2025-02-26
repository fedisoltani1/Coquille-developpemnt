using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ModesReglementPaiementRepository(ColiZenDbContext dbContext)
      : Repository<ModesReglementPaiement, int>(dbContext), IModesReglementPaiementRepository
    {
    }
}
