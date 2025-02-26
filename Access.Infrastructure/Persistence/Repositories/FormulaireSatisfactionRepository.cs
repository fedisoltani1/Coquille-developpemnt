using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class FormulaireSatisfactionRepository(ColiZenDbContext dbContext)
      : Repository<FormulaireSatisfaction, int>(dbContext), IFormulaireSatisfactionRepository
    {
    }
}
