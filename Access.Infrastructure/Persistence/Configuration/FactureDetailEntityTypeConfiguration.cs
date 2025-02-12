using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class FactureDetailEntityTypeConfiguration
         : IEntityTypeConfiguration<FactureLigne>
    {
        public void Configure(EntityTypeBuilder<FactureLigne> builder)
        {
            builder.ToTable("FactureLignes");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
      .ValueGeneratedOnAdd();
            builder.Property(e => e.FactureArticleIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.FactureArticlePuHt).HasColumnType("decimal(18, 3)");
            builder.Property(e => e.FactureArticlePuTtc).HasColumnType("decimal(18, 3)");
            builder.Property(e => e.MontantHt).HasColumnType("decimal(18, 3)");
            builder.Property(e => e.MontantTtc).HasColumnType("decimal(18, 3)");
            builder.Property(e => e.MontantTva).HasColumnType("decimal(18, 3)");
            builder.Property(e => e.TaxeTaux).HasColumnType("decimal(18, 3)");
        }
    }
}
