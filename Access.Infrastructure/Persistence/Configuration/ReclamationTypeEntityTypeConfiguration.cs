using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ReclamationTypeEntityTypeConfiguration
         : IEntityTypeConfiguration<ReclamationType>
    {
        public void Configure(EntityTypeBuilder<ReclamationType> builder)
        {
            builder.ToTable("ReclamationTypes");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
 .ValueGeneratedOnAdd();
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");
            builder.Property(e => e.SocieteDepartementIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
