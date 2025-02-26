using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class SocieteDepartementEntityTypeConfiguration
         : IEntityTypeConfiguration<SocieteDepartement>
    {
        public void Configure(EntityTypeBuilder<SocieteDepartement> builder)
        {
            builder.ToTable("SocieteDepartements");
            builder.HasKey(e => e.Id).HasName("PK_Departements");
            builder.Property(e => e.Id)
                 .ValueGeneratedOnAdd();

            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");

            builder.HasOne(d => d.Collaborateur).WithMany(p => p.SocieteDepartements)
                .HasForeignKey(d => d.CollaborateurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SocieteDepartements_Collaborateurs").OnDelete(DeleteBehavior.NoAction);

        }
    }
}
