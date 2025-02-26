using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ReclamationEntityTypeConfiguration
         : IEntityTypeConfiguration<Reclamation>
    {
        public void Configure(EntityTypeBuilder<Reclamation> builder)
        {
            builder.ToTable("Reclamations");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();
            builder.Property(e => e.ClientIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CommandeNumero)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CreationLe).HasColumnType("datetime");
            builder.Property(e => e.CreationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IsCloture).HasColumnName("isCloture");
            builder.Property(e => e.Message).HasColumnType("text");
            builder.Property(e => e.ModificationLe).HasColumnType("datetime");
            builder.Property(e => e.ModificationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Numero)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ReclamationPrioriteIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ReclamationStatutIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ReclamationTypeIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.SocieteDepartementIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
