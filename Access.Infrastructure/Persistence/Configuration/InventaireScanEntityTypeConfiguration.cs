using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class InventaireScanEntityTypeConfiguration
         : IEntityTypeConfiguration<InventaireScan>
    {
        public void Configure(EntityTypeBuilder<InventaireScan> builder)
        {
            builder.ToTable("InventaireScan");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
  .ValueGeneratedOnAdd();
            builder.Property(e => e.CommandeNumero)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.DateScan).HasColumnType("datetime");
        }
    }
}
