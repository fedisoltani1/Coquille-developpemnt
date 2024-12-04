using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class DomaineValeurElementEntityTypeConfiguration
      : IEntityTypeConfiguration<DomaineValeurElement>
    {
        public void Configure(EntityTypeBuilder<DomaineValeurElement> builder)
        {
            builder.ToTable("APV_ELEMN_DOMN");

            builder.HasKey(e => e.Id)
               .HasName("ELEDO_PK");

            builder.HasIndex(e => new { e.Id, e.Code }, "ELEDO_01_UK")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("IDE_ELEMN_DOMN");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("COD_ELEMN");

            builder.Property(e => e.DateDebut)
                .HasColumnType("datetime")
                .HasColumnName("DAT_DEBUT_APPLQ");

            builder.Property(e => e.DateFin)
                .HasColumnType("datetime")
                .HasColumnName("DAT_FIN_APPLQ");

            builder.Property(e => e.DescriptionComplete)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DES_COMPL_ELEMN");

            builder.Property(e => e.CodeDomaineValeur)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COD_DOMN");

            builder.Property(e => e.DescriptionCourte)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_COURT_ELEMN");

            builder.Property(e => e.SequenceAffichage).HasColumnName("SEQ_AFFCH");

            builder.HasOne(e => e.DomaineValeur)
                .WithMany(d => d.Elements)
                .HasForeignKey(e => e.CodeDomaineValeur)
                .HasPrincipalKey(d => d.Code)
                .HasConstraintName("AA_ELEMN_DOMN_AA_DOMN_VALR_FK");
        }
    }
}
