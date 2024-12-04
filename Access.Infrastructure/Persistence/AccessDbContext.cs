using Microsoft.EntityFrameworkCore;

namespace Access.Infrastructure.Persistence
{
    internal class AccessDbContext(DbContextOptions<AccessDbContext> options)
      : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccessDbContext).Assembly);
        }
    }
}
