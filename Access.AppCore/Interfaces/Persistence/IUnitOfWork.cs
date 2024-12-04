using Access.AppCore.Models;

namespace Access.AppCore.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        Task<Resultat<int>> SauvegarderResultatAsync();

        void InscrireSupprime<TEntity>(TEntity entity);

        public void Detacher<TEntity>(TEntity entity);
    }
}
