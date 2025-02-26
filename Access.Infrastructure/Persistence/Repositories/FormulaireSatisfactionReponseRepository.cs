using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Repositories;

namespace Access.Infrastructure.Persistence.Repositories
{
    internal class FormulaireSatisfactionReponseRepository(ColiZenDbContext dbContext)
      : Repository<FormulaireSatisfactionReponse, int>(dbContext), IFormulaireSatisfactionReponseRepository
    {
    }
}
