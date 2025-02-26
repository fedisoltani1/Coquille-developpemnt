using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class VehiculeTypeRepository(ColiZenDbContext dbContext)
      : Repository<VehiculeType, int>(dbContext), IVehiculeTypeRepository
    {
    }
}
