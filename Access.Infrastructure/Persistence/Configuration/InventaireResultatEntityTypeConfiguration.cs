using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class InventaireResultatEntityTypeConfiguration
         : IEntityTypeConfiguration<InventaireResultat>
    {
        public void Configure(EntityTypeBuilder<InventaireResultat> builder)
        {
            builder.ToTable("InventaireResultat");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
  .ValueGeneratedOnAdd();
            builder.Property(e => e.CommandeNumero)
                .HasMaxLength(100)
                .IsUnicode(false);

        }
    }
}
