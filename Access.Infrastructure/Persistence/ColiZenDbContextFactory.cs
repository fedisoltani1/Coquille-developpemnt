using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Access.Infrastructure.Persistence
{
    public class ColiZenDbContextFactory : IDesignTimeDbContextFactory<ColiZenDbContext>
    {
        public ColiZenDbContext CreateDbContext(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var appSettingsPath = Path.Combine(currentDirectory, "../Access.Web/appsettings.json");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile(appSettingsPath, optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ColiZenDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnexionApplicative"));

            return new ColiZenDbContext(optionsBuilder.Options);
        }
    }
}
