using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class CollaborateurRepository(ColiZenDbContext dbContext)
      : Repository<Collaborateur, int>(dbContext), ICollaborateurRepository
    {
    }
}
