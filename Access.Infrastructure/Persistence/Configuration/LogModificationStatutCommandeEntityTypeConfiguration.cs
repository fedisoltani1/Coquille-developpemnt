using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class LogModificationStatutCommandeEntityTypeConfiguration
         : IEntityTypeConfiguration<LogModificationStatutCommande>
    {
        public void Configure(EntityTypeBuilder<LogModificationStatutCommande> builder)
        {
            builder.ToTable("LogModificationStatutCommande");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
  .ValueGeneratedOnAdd();
            builder.Property(e => e.CommandeNumero)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CommandeStatutActuelIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CommandeStatutModifierIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ModificationLe).HasColumnType("datetime");
            builder.Property(e => e.ModificationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
