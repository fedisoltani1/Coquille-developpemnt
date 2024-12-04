using Access.AppCore.Commun;
using Access.AppCore.Interfaces.Persistence;
using Access.AppCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Access.Infrastructure.Persistence
{
    internal class UnitOfWork(AccessDbContext dbContext)
    : IUnitOfWork
    {
        public async Task<Resultat<int>> SauvegarderResultatAsync()
        {
            try
            {
                var nbEntitesSauvegardees = await dbContext.SaveChangesAsync();
                return Resultat<int>.Success(nbEntitesSauvegardees);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Resultat<int>.Fail(new Message(Constantes.ErreurConcurrence, "ERR_0001"));
            }
        }

        public void InscrireSupprime<TEntity>(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Detacher<TEntity>(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Detached;
        }
    }
}
