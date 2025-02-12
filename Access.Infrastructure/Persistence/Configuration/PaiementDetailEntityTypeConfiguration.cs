using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class PaiementDetailEntityTypeConfiguration
         : IEntityTypeConfiguration<PaiementDetail>
    {
        public void Configure(EntityTypeBuilder<PaiementDetail> builder)
        {
            builder.ToTable("PaiementDetails");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
  .ValueGeneratedOnAdd();
            builder.Property(e => e.CommandeNumero)
               .HasMaxLength(100)
               .IsUnicode(false);
            builder.Property(e => e.Montant).HasColumnType("decimal(18, 3)");
            builder.Property(e => e.PaiementNumero)
                .HasMaxLength(100)
                .IsUnicode(false);

        }
    }
}
