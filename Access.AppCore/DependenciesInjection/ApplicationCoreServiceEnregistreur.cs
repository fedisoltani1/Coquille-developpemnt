
using Access.AppCore.Mappages;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Access.AppCore.DependenciesInjection
{
    internal class ApplicationCoreServiceEnregistreur : IServiceEnregistreur
    {
        public void Enregistrer(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AccessApplicationCoreProfile));
        }
    }
}
