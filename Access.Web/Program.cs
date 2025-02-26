using Access.Web.DependenciesInjection;
using NLog;

namespace Access.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new NLog.Extensions.Logging.NLogLoggerFactory();
            var logger = factory.CreateLogger(typeof(Program).ToString());

            try
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.ConfigurerServices()
                       .ConfigurerIntergiciels(builder.Configuration)
                       .Demarrer();
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                Console.WriteLine(ex); // Log the exception
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }
}
