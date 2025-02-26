using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class VehiculeRepository(ColiZenDbContext dbContext)
      : Repository<Vehicule, int>(dbContext), IVehiculeRepository
    {
    }
}
