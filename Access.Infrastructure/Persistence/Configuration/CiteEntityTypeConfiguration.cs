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
                    ;
            builder.Property(e => e.Id)
       .ValueGeneratedOnAdd();
            builder.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.HasOne(d => d.Gouvernorat).WithMany(p => p.Cites)
              .HasForeignKey(d => d.GouvernoratId)
              .HasConstraintName("FK_Cites_Gouvernorats")
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Ville).WithMany(p => p.Cites)
                .HasForeignKey(d => d.VilleId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Cites_Villes")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
