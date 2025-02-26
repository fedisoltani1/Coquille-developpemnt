using Access.AppCore.DependenciesInjection;
using Access.Infrastructure.Persistence;
using Access.Web.DependenciesInjection;
using Access.Web.Mapping;
using Application.Configuration.ExtentionsExtractor;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Access.Web.DependenciesInjection
{
    internal class WebServiceEnregistreur : IServiceEnregistreur
    {
        public void Enregistrer(IServiceCollection services, IConfiguration configuration)
        {
            // Configuration d'AutoMapper
            services.AddScoped<ApplicationConfigExtractor>();
            services.AddScoped<DatabaseInitializer>();
            services.AddSingleton<DbContextConnectionStrings>();
            services.AddAutoMapper(typeof(AccessWebProfile));

            // Configuration des sessions
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDbContext<ColiZenDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnexionApplicative"))
            );

            // Ajout des contrôleurs avec vues
            services.AddControllersWithViews();
            services.AddRazorPages();


            // Configuration des cookies
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });
        }
    }
}
