using Access.AppCore.DependenciesInjection;
using Access.Infrastructure.Persistence;
using Access.Web.Mapping;
using Application.Configuration.ExtentionsExtractor;
using Microsoft.EntityFrameworkCore;

namespace Access.Web.DependenciesInjection
{
    internal class WebServiceEnregistreur : IServiceEnregistreur
    {
        public void Enregistrer(IServiceCollection services, IConfiguration configuration)
        {
            // Mappings de automapper
            services.AddScoped<ApplicationConfigExtractor>();
            services.AddScoped<DatabaseInitializer>();
            services.AddSingleton<DbContextConnectionStrings>();
            services.AddAutoMapper(typeof(AccessWebProfile));
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddRazorPages();
            //services.AddDbContext<ColiZenDbContext>((serviceProvider, options) =>
            //{
            //    var dbContextConfig = serviceProvider.GetRequiredService<DbContextConnectionStrings>();
            //    options.UseSqlServer(dbContextConfig.GetConnectionString().applicationDatabase);
            //});
            // protection du cookie de l'application
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });
        }
    }
}
