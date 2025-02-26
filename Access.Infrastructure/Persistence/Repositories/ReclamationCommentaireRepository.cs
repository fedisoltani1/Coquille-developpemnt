using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class ReclamationCommentaireRepository(ColiZenDbContext dbContext)
      : Repository<ReclamationCommentaire, int>(dbContext), IReclamationCommentaireRepository
    {
    }
}
