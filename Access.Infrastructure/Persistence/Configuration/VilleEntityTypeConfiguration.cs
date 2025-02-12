using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class VilleEntityTypeConfiguration
         : IEntityTypeConfiguration<Ville>
    {
        public void Configure(EntityTypeBuilder<Ville> builder)
        {
            builder.ToTable("Villes");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
 .ValueGeneratedOnAdd();
            builder.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.GouvernoratIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.Gouvernorat).WithMany(p => p.Villes)
                .HasForeignKey(d => d.GouvernoratId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Villes_Gouvernorats");
        }
    }
}
