namespace Access.Infrastructure.Persistence.Repositories
{
    using Access.AppCore.Entities;
    using Access.AppCore.Interfaces.Persistances.Repositories;
    using Access.Infrastructure.Persistence;

    internal class DomaineValeurRepository(AccessDbContext dbContext)
      : Repository<DomaineValeur, int>(dbContext), IDomaineValeurRepository
    {
        public IEnumerable<DomaineValeur> AutreMethodeObtenir()
        {
            // this.Entite.Include(e => e.Xxx)
            //           .ThenInclude(x => x.Yyy)
            //           .Where(x => x.Uuu = Uuu);
            throw new NotImplementedException();
        }
    }
}
