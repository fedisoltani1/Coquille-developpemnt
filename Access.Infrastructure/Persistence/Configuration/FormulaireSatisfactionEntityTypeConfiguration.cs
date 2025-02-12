using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class FormulaireSatisfactionEntityTypeConfiguration
         : IEntityTypeConfiguration<FormulaireSatisfaction>
    {
        public void Configure(EntityTypeBuilder<FormulaireSatisfaction> builder)
        {
            builder.ToTable("FormulaireSatisfaction");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
      .ValueGeneratedOnAdd();
            builder.Property(e => e.CreationLe).HasColumnType("datetime");
            builder.Property(e => e.CreationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");
            builder.Property(e => e.Numero)
                .HasMaxLength(100)
                .IsUnicode(false);

        }
    }
}
