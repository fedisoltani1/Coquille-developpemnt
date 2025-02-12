using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Console = Access.AppCore.Entities.Console;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ConsoleEntityTypeConfiguration
         : IEntityTypeConfiguration<Console>
    {
        public void Configure(EntityTypeBuilder<Console> builder)
        {
            builder.ToTable("Consoles");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
      .ValueGeneratedOnAdd();
            builder.Property(e => e.ConsoleStatutIntitule)
               .HasMaxLength(100)
               .IsUnicode(false);
            builder.Property(e => e.CreationLe).HasColumnType("datetime");
            builder.Property(e => e.CreationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ModificationLe).HasColumnType("datetime");
            builder.Property(e => e.ModificationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Numero)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.SocieteAgenceDestinationIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.SocieteAgenceSourceIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
