using Access.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Access.Web.DependenciesInjection
{
    internal static class SoftwareConfigExtentions
    {
        internal static WebApplication ConfigurerIntergiciels(this WebApplication app, IConfiguration configuration)
        {
            // Appliquer les migrations avant de démarrer les intergiciels
            //using (var scope = app.Services.CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetRequiredService<ColiZenDbContext>();
            //    dbContext.Database.Migrate(); // Applique les migrations ici
            //}

            // Configuration des intergiciels

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            DatabaseInitializer.ApplyAllMigrations(app);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                Secure = CookieSecurePolicy.Always,
            });

            app.UseSession();
            app.UseAuthentication();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseAuthorization();

            // Autres configurations des intergiciels...
            
            return app;
        }

        internal static void Demarrer(this WebApplication app)
        {
            app.Run();
        }
    }
}
