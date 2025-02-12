using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class InventaireStatutEntityTypeConfiguration
         : IEntityTypeConfiguration<InventaireStatut>
    {
        public void Configure(EntityTypeBuilder<InventaireStatut> builder)
        {
            builder.ToTable("InventaireStatuts");
            builder.HasKey(e => e.Id).HasName("PK_InventaireStatutss");
            builder.Property(e => e.Id)
  .ValueGeneratedOnAdd();
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
