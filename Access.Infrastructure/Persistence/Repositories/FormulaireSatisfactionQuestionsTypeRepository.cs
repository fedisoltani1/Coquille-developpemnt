using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class FormulaireSatisfactionQuestionsTypeRepository(ColiZenDbContext dbContext)
      : Repository<FormulaireSatisfactionQuestionsType, int>(dbContext), IFormulaireSatisfactionQuestionsTypeRepository
    {
    }
}
