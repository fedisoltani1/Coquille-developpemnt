using Access.AppCore.DependenciesInjection;
using Access.AppCore.Interfaces.Persistances;

using Access.AppCore.Interfaces.Persistence;
using Access.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Access.Infrastructure.DependenciesInjection
{
    public class InfrastructureServiceEnregistreur : IServiceEnregistreur
    {
        public void Enregistrer(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ColiZenDbContext>(options =>
                options
                    .UseSqlServer(configuration.GetConnectionString("ConnexionApplicative"))
                    .EnableSensitiveDataLogging());
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
