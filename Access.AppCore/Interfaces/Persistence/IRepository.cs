using System.Linq.Expressions;
using Access.AppCore.Entities.Bases;
using Microsoft.EntityFrameworkCore.Query;

namespace Access.AppCore.Interfaces.Persistances
{
    public interface IRepository<TEntite, TId>
     where TEntite : EntiteBase<TId>
     where TId : IEquatable<TId>
    {
        void Creer(TEntite entite);

        void Modifier(TEntite entite);

        void Supprimer(TEntite entite);

        Task<TEntite> ObtenirUn(TId cle);

        IQueryable<TEntite> ObtenirTous();

        Task<TEntite> FirstOrDefaultAsync(Expression<Func<TEntite, bool>> expression, params Func<IQueryable<TEntite>, IIncludableQueryable<TEntite, object>>[] includes);

        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<TEntite, bool>> expression);

        Task<TEntite> FirstAsync(
             Expression<Func<TEntite, bool>>? expression = null,
             params Func<IQueryable<TEntite>, IIncludableQueryable<TEntite, object>>[] includes);

        Task<bool> ExistAsync(Expression<Func<TEntite, bool>> expression);

        Task<List<TEntite>> ToListAsync(params Func<IQueryable<TEntite>, IIncludableQueryable<TEntite, object>>[] includes);

        Task<List<TEntite>> ToListAsync(Expression<Func<TEntite, bool>> expression, params Func<IQueryable<TEntite>, IIncludableQueryable<TEntite, object>>[] includes);

        void Detacher(TEntite entite);
    }
}