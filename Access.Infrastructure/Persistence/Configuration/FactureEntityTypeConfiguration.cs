using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class FactureEntityTypeConfiguration
         : IEntityTypeConfiguration<Facture>
    {
        public void Configure(EntityTypeBuilder<Facture> builder)
        {
            builder.ToTable("Factures");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
      .ValueGeneratedOnAdd();
            builder.Property(e => e.CreationLe).HasColumnType("datetime");
            builder.Property(e => e.CreationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ModificationLe).HasColumnType("datetime");
            builder.Property(e => e.ModificationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.MontantHt).HasColumnType("decimal(18, 0)");
            builder.Property(e => e.MontantTpf).HasColumnType("decimal(18, 0)");
            builder.Property(e => e.MontantTtc).HasColumnType("decimal(18, 0)");
            builder.Property(e => e.MontantTva).HasColumnType("decimal(18, 0)");
            builder.Property(e => e.Numero)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
