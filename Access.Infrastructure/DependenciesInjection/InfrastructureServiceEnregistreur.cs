using Access.AppCore.DependenciesInjection;
using Access.AppCore.Interfaces.Persistances;

using Access.AppCore.Interfaces.Persistence;
using Access.AppCore.Interfaces.Persistence.Repositories;
using Access.Infrastructure.Persistence;
using Access.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Access.Infrastructure.DependenciesInjection
{
    public class InfrastructureServiceEnregistreur : IServiceEnregistreur
    {
        public void Enregistrer(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContextPool<ColiZenDbContext>(options =>
            //    options
            //        .UseSqlServer(configuration.GetConnectionString("ConnexionApplicative"))
            //        .EnableSensitiveDataLogging());

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IBanqueRepository, BanqueRepository>();
            services.AddScoped<IChequeRepository, ChequeRepository>();
            services.AddScoped<IChequeStatutRepository, ChequeStatutRepository>();
            services.AddScoped<IChequierRepository, ChequierRepository>();
            services.AddScoped<ICiteRepository, CiteRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientContactRepository, ClientContactRepository>();
            services.AddScoped<IClientTypeRepository, ClientTypeRepository>();
            services.AddScoped<IClientWarehouseRepository, ClientWarehouseRepository>();
            services.AddScoped<ICollaborateurRepository, CollaborateurRepository>();
            services.AddScoped<ICollaborateurRoleRepository, CollaborateurRoleRepository>();
            services.AddScoped<ICommandeCategoryRepository, CommandeCategoryRepository>();
            services.AddScoped<ICommandeEtapeRepository, CommandeEtapeRepository>();
            services.AddScoped<ICommandeStatutRepository, CommandeStatutRepository>();
            services.AddScoped<IConsoleRepository, ConsoleRepository>();
            services.AddScoped<IConsoleStatutRepository, ConsoleStatutRepository>();
            services.AddScoped<IEmballageCommandeStautRepository, EmballageCommandeStautRepository>();
            services.AddScoped<IFacturationCategoryRepository, FacturationCategoryRepository>();
            services.AddScoped<IFactureRepository, FactureRepository>();
            services.AddScoped<IFactureLigneRepository, FactureLigneRepository>();
            services.AddScoped<IFormulaireSatisfactionQuestionRepository, FormulaireSatisfactionQuestionRepository>();
            services.AddScoped<IFormulaireSatisfactionQuestionsTypeRepository, FormulaireSatisfactionQuestionsTypeRepository>();
            services.AddScoped<IFormulaireSatisfactionReponseRepository, FormulaireSatisfactionReponseRepository>();
            services.AddScoped<IGouvernoratRepository, GouvernoratRepository>();
            services.AddScoped<IInventaireRepository, InventaireRepository>();
            services.AddScoped<IInventaireResultatRepository, InventaireResultatRepository>();
            services.AddScoped<IInventaireStatutRepository, InventaireStatutRepository>();
            services.AddScoped<IInventaireScanRepository, InventaireScanRepository>();
            services.AddScoped<IInventaireStockTheoriqueRepository, InventaireStockTheoriqueRepository>();
            services.AddScoped<ILogModificationStatutCommandeRepository, LogModificationStatutCommandeRepository>();
            services.AddScoped<IModesReglementRepository, ModesReglementRepository>();
            services.AddScoped<IModesReglementFacturationRepository, ModesReglementFacturationRepository>();
            services.AddScoped<IModesReglementFacturationRepository, ModesReglementFacturationRepository>();
            services.AddScoped<IModesReglementPaiementRepository, ModesReglementPaiementRepository>();
            services.AddScoped<IMotifsCallCenterRepository, MotifsCallCenterRepository>();
            services.AddScoped<IMotifsLivraisonRepository, MotifsLivraisonRepository>();
            services.AddScoped<IMotifsPickupRepository, MotifsPickupRepository>();
            services.AddScoped<IPaiementRepository, PaiementRepository>();
            services.AddScoped<IReclamationTypeRepository, ReclamationTypeRepository>();
            services.AddScoped<IReclamationCommentaireRepository, ReclamationCommentaireRepository>();
            services.AddScoped<IReclamationPrioriteRepository, ReclamationPrioriteRepository>();
            services.AddScoped<IReclamationRepository, ReclamationRepository>();
            services.AddScoped<ISocieteRepository, SocieteRepository>();
            services.AddScoped<ISocieteAgenceRepository, SocieteAgenceRepository>();
            services.AddScoped<ISocieteDepartementRepository, SocieteDepartementRepository>();
            services.AddScoped<ITaxeRepository, TaxeRepository>();
            services.AddScoped<ITaxeTypeRepository, TaxeTypeRepository>();
            services.AddScoped<IVehiculeRepository, VehiculeRepository>();
            services.AddScoped<IVehiculeTypeRepository, VehiculeTypeRepository>();
            services.AddScoped<IVilleRepository, VilleRepository>();
            services.AddScoped<IZoneVilleRepository, ZoneVilleRepository>();
        }
    }
}
