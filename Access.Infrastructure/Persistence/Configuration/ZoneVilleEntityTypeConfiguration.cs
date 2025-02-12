using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ZoneVilleEntityTypeConfiguration
         : IEntityTypeConfiguration<ZoneVille>
    {
        public void Configure(EntityTypeBuilder<ZoneVille> builder)
        {
            builder.ToTable("ZoneVilles");
            builder.Property(e => e.Id)
 .ValueGeneratedOnAdd();
            builder.HasOne(d => d.Cite).WithMany(p => p.ZoneVilles)
                 .HasForeignKey(d => d.CiteId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_ZoneVilles_Cites");

            builder.HasOne(d => d.Gouvernorat).WithMany(p => p.ZoneVilles)
                .HasForeignKey(d => d.GouvernoratId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZoneVilles_Gouvernorats");

            builder.HasOne(d => d.Ville).WithMany(p => p.ZoneVilles)
                .HasForeignKey(d => d.VilleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZoneVilles_Villes");

            builder.HasOne(d => d.Zone).WithMany(p => p.ZoneVilles)
                .HasForeignKey(d => d.ZoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZoneVilles_Zones");

        }
    }
}
