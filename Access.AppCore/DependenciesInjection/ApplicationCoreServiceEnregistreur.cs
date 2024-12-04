using Access.AppCore.Interfaces.Persistances.Services;
using Access.AppCore.Mappages;
using Access.AppCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Access.AppCore.DependenciesInjection
{
    internal class ApplicationCoreServiceEnregistreur : IServiceEnregistreur
    {
        public void Enregistrer(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDomaineValeurService, DomaineValeurService>();

            services.AddAutoMapper(typeof(AccessApplicationCoreProfile));
        }
    }
}
