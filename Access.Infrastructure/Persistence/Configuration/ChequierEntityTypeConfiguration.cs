using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ChequierEntityTypeConfiguration
         : IEntityTypeConfiguration<Chequier>
    {
        public void Configure(EntityTypeBuilder<Chequier> builder)
        {
            builder.ToTable("Chequiers");
            builder.HasKey(e => e.Id)
                    ;
            builder.Property(e => e.Id)
       .ValueGeneratedOnAdd();
            builder.Property(e => e.ChequierStatutIntitule)
                  .HasMaxLength(100)
                  .IsUnicode(false);
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");
            builder.Property(e => e.NumeroDebut)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.NumeroFin)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.HasOne(d => d.Banque).WithMany(p => p.Chequiers)
               .HasForeignKey(d => d.BanqueId)
               .OnDelete(DeleteBehavior.NoAction)
               .HasConstraintName("FK_Chequiers_Banques");

            builder.HasOne(d => d.ChequierStatut).WithMany(p => p.Chequiers)
                .HasForeignKey(d => d.ChequierStatutId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Chequiers_ChequierStatuts");
        }
    }
}
