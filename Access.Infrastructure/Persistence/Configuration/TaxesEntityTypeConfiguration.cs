using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class TaxesEntityTypeConfiguration
         : IEntityTypeConfiguration<Taxes>
    {
        public void Configure(EntityTypeBuilder<Taxes> builder)
        {
            builder.ToTable("Taxes");
            builder.HasKey(e => e.Id).HasName("PK_TaxesValeurAjoutee");
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
            builder.Property(e => e.Valeur).HasColumnType("decimal(18, 3)");

            builder.HasOne(d => d.TaxeType).WithMany(p => p.Taxes)
                .HasForeignKey(d => d.TaxeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Taxes_Taxes");
        }
    }
}
