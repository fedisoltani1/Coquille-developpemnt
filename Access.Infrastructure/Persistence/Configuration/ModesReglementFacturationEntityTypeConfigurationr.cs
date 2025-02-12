using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ModesReglementFacturationEntityTypeConfigurationr
         : IEntityTypeConfiguration<ModesReglementFacturation>
    {
        public void Configure(EntityTypeBuilder<ModesReglementFacturation> builder)
        {
            builder.ToTable("ModesReglementFacturation");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
  .ValueGeneratedOnAdd();
            builder.Property(e => e.Code)
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
