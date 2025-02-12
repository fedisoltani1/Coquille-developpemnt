using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class InventaireEntityTypeConfiguration
         : IEntityTypeConfiguration<Inventaire>
    {
        public void Configure(EntityTypeBuilder<Inventaire> builder)
        {
            builder.ToTable("Inventaires");
            builder.HasKey(e => e.Id).HasName("PK_InventaireStatuts");
            builder.Property(e => e.Id)
  .ValueGeneratedOnAdd();
            builder.Property(e => e.CreationLe)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CreationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Date).HasColumnType("datetime");
            builder.Property(e => e.Numero)
                .HasMaxLength(100)
                .IsUnicode(false);

        }
    }
}
