using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Access.Infrastructure.Persistence.Configuration
{
    public class EmballageCommandeStautEntityTypeConfiguration
         : IEntityTypeConfiguration<EmballageCommandeStaut>
    {
        public void Configure(EntityTypeBuilder<EmballageCommandeStaut> builder)
        {
            builder.ToTable("EmballageCommandeStauts");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
      .ValueGeneratedOnAdd();
            builder.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
