using System.Linq.Expressions;
using Access.AppCore.Entities.Bases;
using Access.AppCore.Interfaces.Persistances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Access.Infrastructure.Persistence
{
    internal class Repository<TEntite, TId>(ColiZenDbContext dbContext)
     : IRepository<TEntite, TId>
     where TEntite : EntiteBase<TId>
     where TId : IEquatable<TId>
    {
        protected internal DbSet<TEntite> Entites => dbContext.Set<TEntite>();

        public void Creer(TEntite entite) => Entites.Add(entite);

        public void Modifier(TEntite entite) => Entites.Update(entite);

        public void Supprimer(TEntite entite) => Entites.Remove(entite);

        public async Task<TEntite> ObtenirUn(TId cle)
        {
            ArgumentNullException.ThrowIfNull(nameof(cle));
            return (await Entites.FindAsync(cle)) !;
        }

        public IQueryable<TEntite> ObtenirTous() => Entites;

        public virtual async Task<TEntite> FirstOrDefaultAsync(Expression<Func<TEntite, bool>> expression, params Func<IQueryable<TEntite>, IIncludableQueryable<TEntite, object>>[] includes)
        {
            IQueryable<TEntite> requete = Entites;

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    requete = include(requete);
                }
            }

            return (await requete.FirstOrDefaultAsync(expression)) !;
        }

        public virtual async Task<int> CountAsync()
        {
            return await Entites.CountAsync();
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntite, bool>> expression)
        {
            return await Entites.CountAsync(expression);
        }

        public virtual async Task<bool> ExistAsync(Expression<Func<TEntite, bool>> expression)
        {
            return await Entites.AnyAsync(expression);
        }

        public virtual async Task<List<TEntite>> ToListAsync(params Func<IQueryable<TEntite>, IIncludableQueryable<TEntite, object>>[] includes)
        {
            IQueryable<TEntite> requete = Entites;
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    requete = include(requete);
                }
            }

            return await requete.ToListAsync();
        }

        public virtual async Task<List<TEntite>> ToListAsync(Expression<Func<TEntite, bool>> expression, params Func<IQueryable<TEntite>, IIncludableQueryable<TEntite, object>>[] includes)
        {
            IQueryable<TEntite> requete = Entites;

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    requete = include(requete);
                }
            }

            return await requete.Where(expression).ToListAsync();
        }
    }
}
