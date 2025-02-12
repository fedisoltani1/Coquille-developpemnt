using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class FormulaireSatisfactionQuestionsTypeEntityTypeConfiguration
         : IEntityTypeConfiguration<EmballageCommandeStaut>
    {
        public void Configure(EntityTypeBuilder<EmballageCommandeStaut> builder)
        {
            builder.ToTable("FormulaireSatisfactionQuestionsTypes");
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
