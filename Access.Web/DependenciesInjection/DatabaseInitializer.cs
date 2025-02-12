using Access.Infrastructure.Persistence;
using Application.Configuration.ExtentionsExtractor;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Access.Web.DependenciesInjection
{
    public class DatabaseInitializer
    {
        public static void ApplyAllMigrations(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContexts = new List<DbContext>()
                {
                    scope.ServiceProvider.GetRequiredService<ColiZenDbContext>(),
                };

                var databaseToBackup = new List<DbContext>()
                {
                    scope.ServiceProvider.GetRequiredService<ColiZenDbContext>(),
                };

                // Backup databases
                foreach (var dbContext in databaseToBackup)
                {
                    if (dbContext.Database.GetPendingMigrations().Any())
                    {
                        try
                        {
                            BackupDatabase(dbContext);
                        }
                        catch (Exception ex)
                        {
                            LogManager.GetCurrentClassLogger().Error($"Erreur lors de la sauvegarde de la base de données : {ex.Message}");
                        }
                    }
                }

                // Migrate databases
                foreach (var dbContext in dbContexts)
                {
                    try
                    {
                        if (dbContext.Database.GetPendingMigrations().Any())
                        {
                            dbContext.Database.Migrate();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogManager.GetCurrentClassLogger().Error($"Erreur lors de la migration de la base de données : {ex.Message}");
                    }
                }
            }
        }

        private static void BackupDatabase(DbContext dbContext)
        {
            if (dbContext.Database.CanConnect())
            {
                var connection = dbContext.Database.GetDbConnection();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                string databaseName = connection.Database;
                string backupDirectory = ApplicationConfigExtractor.GetDatabaseBackupPath();
                string backupFilePath = Path.Combine(backupDirectory, $"{databaseName}-{DateTime.Now:yyyyMMddHHmmss}.bak");
                string backupSql = $@"
                BACKUP DATABASE [{databaseName}]
                TO DISK = '{backupFilePath}'
                WITH NOFORMAT, NOINIT, NAME = N'{databaseName}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = backupSql;
                    command.CommandTimeout = 10;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
