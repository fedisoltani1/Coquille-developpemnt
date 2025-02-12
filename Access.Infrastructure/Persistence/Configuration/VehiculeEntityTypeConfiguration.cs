using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class VehiculeEntityTypeConfiguration
         : IEntityTypeConfiguration<Vehicule>
    {
        public void Configure(EntityTypeBuilder<Vehicule> builder)
        {
            builder.ToTable("Vehicules");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
 .ValueGeneratedOnAdd();
            builder.Property(e => e.CreationLe).HasColumnType("datetime");
            builder.Property(e => e.CreationPar).HasColumnType("datetime");
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");
            builder.Property(e => e.IsGps).HasColumnName("isGPS");
            builder.Property(e => e.Marque)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Matricule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Modele)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ModificationLe)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ModificationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.VehiculeTypeIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
