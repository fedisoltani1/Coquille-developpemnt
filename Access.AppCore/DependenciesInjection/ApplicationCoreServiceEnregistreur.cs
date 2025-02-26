
using Access.AppCore.Interfaces.Persistence.Repositories;
using Access.AppCore.Interfaces.Persistence.Services;
using Access.AppCore.Mappages;
using Access.AppCore.Services;
using Access.AppCore.Validator;
using Access.AppCore.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Access.AppCore.DependenciesInjection
{
    internal class ApplicationCoreServiceEnregistreur : IServiceEnregistreur
    {
        public void Enregistrer(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AccessApplicationCoreProfile));

            // Injection des validateurs
            services.AddScoped<SocieteValidator>();
            services.AddScoped<SocieteAgenceValidator>();
            services.AddScoped<GouvernoratValidator>();
            services.AddScoped<CiteValidator>();
            services.AddScoped<VilleValidator>();

            // Injection des Service
            services.AddScoped<ISocieteService, SocieteService>();
            services.AddScoped<ISocieteAgenceService, SocieteAgenceService>();
            services.AddScoped<IGouvernoratService, GouvernoratService>();
            services.AddScoped<ICiteService, CiteService>();
            services.AddScoped<IVilleService, VilleService>();
        }
    }
}
