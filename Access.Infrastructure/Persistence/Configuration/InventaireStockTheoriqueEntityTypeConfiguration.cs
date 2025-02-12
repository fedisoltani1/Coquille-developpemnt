using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class InventaireStockTheoriqueEntityTypeConfiguration
         : IEntityTypeConfiguration<InventaireStockTheorique>
    {
        public void Configure(EntityTypeBuilder<InventaireStockTheorique> builder)
        {
            builder.ToTable("InventaireStockTheorique");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
  .ValueGeneratedOnAdd();
            builder.Property(e => e.CommandeNumero)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
