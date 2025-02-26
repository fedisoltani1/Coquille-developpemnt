using System.Reflection;
using Access.AppCore.DependenciesInjection;
using Access.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Access.Web.DependenciesInjection
{
    internal static class ConfigurationServicesExtensions
    {
        internal static WebApplication ConfigurerServices(this WebApplicationBuilder builder)
        {
            // Replace AddRazorPages with AddControllersWithViews
            var mvcBuilder = builder.Services.AddControllersWithViews();
            mvcBuilder.AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            

            // Optional session handling filter
            // Uncomment if you need session expiration handling
            // mvcBuilder.AddMvcOptions(options =>
            // {
            //     options.Filters.Add(new VerificationSessionFilter());
            // });
            //builder.Services.AddDbContext<ColiZenDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnexionApplicative"))
            //);

            if (builder.Environment.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }

            Type interfaceType = typeof(IServiceEnregistreur);
            var implementingClasses = ObtenirClasses(interfaceType);
            foreach (var type in implementingClasses)
            {
                var enre = Activator.CreateInstance(type) as IServiceEnregistreur;
                enre?.Enregistrer(builder.Services, builder.Configuration);
            }

            return builder.Build();
        }

        private static List<Type> ObtenirClasses(Type interfaceType)
        {
            var implementations = new List<Type>();
            var assemblies = ChargerReferences();
            foreach (var assembly in assemblies)
            {
                try
                {
                    var types = assembly.GetTypes();
                    foreach (var type in types)
                    {
                        if (type.IsClass && !type.IsAbstract && interfaceType.IsAssignableFrom(type))
                        {
                            implementations.Add(type);
                        }
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                    Console.WriteLine($"Error loading assembly {assembly.FullName}: {ex.Message}");
                }
            }

            return implementations;
        }

        private static List<Assembly> ChargerReferences()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var pathAssemblies = assemblies.Select(a => a.Location).ToArray();
            var pathReferences = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            foreach (var path in pathReferences)
            {
                try
                {
                    if (!pathAssemblies.Contains(path, StringComparer.InvariantCultureIgnoreCase))
                    {
                        assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path)));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unable to load assembly: {path}, Error: {ex.Message}");
                }
            }

            return assemblies;
        }
    }
}
