using Access.AppCore.Entities;
using Application.Configuration.ExtentionsExtractor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Console = Access.AppCore.Entities.Console;

namespace Access.Infrastructure.Persistence
{
    public class ColiZenDbContext : DbContext
    {
        public ColiZenDbContext(DbContextOptions<ColiZenDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColiZenDbContext).Assembly);
            SocieteDataSeed(modelBuilder);
        }

        private void SocieteDataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Societe>().HasData(
                new Societe
                {
                    Id = 1,
                    RaisonSocial = "cc",
                    MatriculeFiscale = "0000000/A/A/A/000",
                    RegistreCommerce = "L/05/500/m",
                    Activite = "Livraison",
                    NomCommercial = "KoliZen",
                    Gouvernorat = "Tunis",
                    Ville = "Tunis",
                    Adresse = "Lac2",
                    CodePostal = "2025",
                    AdresseMail = "KoliZen@mail.com",
                    Telephone = "00000000",
                    Secteur = "Livraison",
                    PremierResponsable = "Fedi",
                }
            );
        }
    }
}
