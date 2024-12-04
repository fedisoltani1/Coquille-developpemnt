using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Access.AppCore.DependenciesInjection
{
    public interface IServiceEnregistreur
    {
        void Enregistrer(IServiceCollection services, IConfiguration configuration);
    }
}
