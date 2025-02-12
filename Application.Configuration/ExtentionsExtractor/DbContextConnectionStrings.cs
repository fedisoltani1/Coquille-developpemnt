using Application.Configuration.Extentions;

namespace Application.Configuration.ExtentionsExtractor
{
    public class DbContextConnectionStrings
    {
        private readonly DatabasesConnextionStrings _connectionStrings;

        public DbContextConnectionStrings()
        {
            _connectionStrings = new DatabasesConnextionStrings();
            var database = ApplicationConfigExtractor.GetDatabaseContext();
            _connectionStrings.applicationDatabase = "Server=" + database.Server + ";Database=" + database.Database + ";User id=" + database.UserSql + ";Password=" + database.PasswordSql + ";TrustServerCertificate=true;";
        }

        public DatabasesConnextionStrings GetConnectionString()
        {
            return _connectionStrings;
        }
    }
}
