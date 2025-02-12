using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class CiteEntityTypeConfiguration
         : IEntityTypeConfiguration<Cite>
    {
        public void Configure(EntityTypeBuilder<Cite> builder)
        {
            builder.ToTable("Cites");
            builder.HasKey(e => e.Id)
                     .HasName("Id");
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
            builder.Property(e => e.VilleIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.HasOne(d => d.Gouvernorat).WithMany(p => p.Cites)
              .HasForeignKey(d => d.GouvernoratId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_Cites_Gouvernorats");

            builder.HasOne(d => d.Ville).WithMany(p => p.Cites)
                .HasForeignKey(d => d.VilleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cites_Villes");
        }
    }
}
