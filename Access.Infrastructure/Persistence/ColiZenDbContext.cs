using Access.AppCore.Entities;
using Application.Configuration.ExtentionsExtractor;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Societe>().HasData(
                new Societe
                {
                    Id = 1,
                    RaisonSocial = "xxx",
                    MatriculeFiscale = "0000000/A/A/A/000",
                    RegistreCommerce = "xxxx",
                    Activite = "Livraison",
                    NomCommercial = "KoliZen",
                    Gouvernorat = "Tunis",
                    Ville = "Tunis",
                    Adresse = "Lac2",
                    CodePostal = "2025",
                    AdresseMail = "KoliZen@mail.com",
                    Telephone = "00000000",
                    Secteur = "x",
                    PremierResponsable = "Fedi",
                }
            );
        }
    }
}
