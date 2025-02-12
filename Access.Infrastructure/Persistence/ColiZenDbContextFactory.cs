using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Access.Infrastructure.Persistence
{
    public class ColiZenDbContextFactory : IDesignTimeDbContextFactory<ColiZenDbContext>
    {
        public ColiZenDbContext CreateDbContext(string[] args)
        {
            // Get the current directory of the Access.Infrastructure project
            var currentDirectory = Directory.GetCurrentDirectory();

            // Combine the current directory with the relative path to the Access.Web appsettings.json
            // Since Access.Web is a class library, we use the appropriate relative path.
            var appSettingsPath = Path.Combine(currentDirectory, "../Access.Web/appsettings.json");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)  // Set base path to the current directory of Access.Infrastructure
                .AddJsonFile(appSettingsPath, optional: false)  // Point to the appsettings.json in Access.Web
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ColiZenDbContext>();

            // Use the connection string from the appsettings.json
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ColiZenDbContext(optionsBuilder.Options);
        }
    }
}
