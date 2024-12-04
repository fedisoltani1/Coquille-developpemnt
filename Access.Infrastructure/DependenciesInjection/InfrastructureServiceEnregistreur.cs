using Access.AppCore.DependenciesInjection;
using Access.AppCore.Interfaces.Persistances;
using Access.AppCore.Interfaces.Persistances.Repositories;
using Access.AppCore.Interfaces.Persistence;
using Access.Infrastructure.Persistence;
using Access.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Access.Infrastructure.DependenciesInjection
{
    internal class InfrastructureServiceEnregistreur : IServiceEnregistreur
    {
        public void Enregistrer(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AccessDbContext>(options =>
                options
                    .UseSqlServer(configuration.GetConnectionString("ConnexionApplicative"))
                    .EnableSensitiveDataLogging());

            services.AddScoped<IDomaineValeurRepository, DomaineValeurRepository>();
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
