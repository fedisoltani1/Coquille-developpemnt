namespace Access.Web.DependenciesInjection
{
    internal static class SoftwareConfigExtentions
    {
        internal static WebApplication ConfigurerIntergiciels(this WebApplication app, IConfiguration configuration)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Erreur/ErreurTechnique");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                Secure = CookieSecurePolicy.Always,
            });

            // la session est toujours disponible
            app.UseSession();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            // protection de certains contenus avec des paramètres dans l'entête de réponse
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Append("Content-Security-Policy", "default-src 'self' 'unsafe-inline' 'unsafe-eval' *.blob.core.windows.net; frame-ancestors 'self'; img-src 'self' *.blob.core.windows.net data:;");
                context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");
                await next();
            });

            app.MapRazorPages();
            using (var scope = app.Services.CreateScope())
            {
                // scope.ServiceProvider.AjouterDonneesClientExemple();
            }

            return app;
        }

        internal static void Demarrer(this WebApplication app)
        {
            app.Run();
        }
    }
}
