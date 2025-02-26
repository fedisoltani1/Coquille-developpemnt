using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class CollaborateurRoleRepository(ColiZenDbContext dbContext)
      : Repository<CollaborateurRole, int>(dbContext), ICollaborateurRoleRepository
    {
    }
}
