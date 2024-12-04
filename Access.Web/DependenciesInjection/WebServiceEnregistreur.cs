using Access.AppCore.DependenciesInjection;
using Access.Web.Mapping;

namespace Access.Web.DependenciesInjection
{
    internal class WebServiceEnregistreur : IServiceEnregistreur
    {
        public void Enregistrer(IServiceCollection services, IConfiguration configuration)
        {
            // Mappings de automapper
            services.AddAutoMapper(typeof(AccessWebProfile));

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddRazorPages();

            // protection du cookie de l'application
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });
        }
    }
}
