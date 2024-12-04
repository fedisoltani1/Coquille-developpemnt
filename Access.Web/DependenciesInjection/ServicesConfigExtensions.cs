using System.Reflection;
using Access.AppCore.DependenciesInjection;
using Newtonsoft.Json;

namespace Access.Web.DependenciesInjection
{
    internal static class ConfigurationServicesExtensions
    {
        internal static WebApplication ConfigurerServices(this WebApplicationBuilder builder)
        {
            var razor = builder.Services.AddRazorPages();

            razor.AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                 .AddViewLocalization()
                 .AddDataAnnotationsLocalization();

            // OPTIONNEL : si l'application veut gérer l'expiration de la session, habituellement non requis,
            // il faut ajouter l'option suivante aux pages Razor
            // razor.AddMvcOptions(options =>
            // {
            //     options.Filters.Add(new VerificationSessionFilter());
            // });
            if (builder.Environment.IsDevelopment())
            {
                razor.AddRazorRuntimeCompilation();
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
            var implemtations = new List<Type>();
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
                            implemtations.Add(type);
                        }
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                    Console.WriteLine($"Erreur de chargement dans l'assembly {assembly.FullName}: {ex.Message}");
                }
            }

            return implemtations;
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
                    Console.WriteLine($"Impossible de charger l'assembly : {path}, Erreur : {ex.Message}");
                }
            }

            return assemblies;
        }
    }
}
