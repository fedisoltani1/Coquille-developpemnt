using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ReclamationPrioriteEntityTypeConfiguration
         : IEntityTypeConfiguration<ReclamationPriorite>
    {
        public void Configure(EntityTypeBuilder<ReclamationPriorite> builder)
        {
            builder.ToTable("ReclamationPriorites");
            builder.HasKey(e => e.Id).HasName("PK_Table_3");
            builder.Property(e => e.Id)
 .ValueGeneratedOnAdd();

            builder.Property(e => e.Couleur)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");

        }
    }
}
