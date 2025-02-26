using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class FormulaireSatisfactionQuestionRepository(ColiZenDbContext dbContext)
      : Repository<FormulaireSatisfactionQuestion, int>(dbContext), IFormulaireSatisfactionQuestionRepository
    { 

    }
}
