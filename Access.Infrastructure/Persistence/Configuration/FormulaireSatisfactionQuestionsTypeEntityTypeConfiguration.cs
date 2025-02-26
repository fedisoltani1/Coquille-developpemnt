using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class FormulaireSatisfactionQuestionsTypeEntityTypeConfiguration
         : IEntityTypeConfiguration<FormulaireSatisfactionQuestionsType>
    {
        public void Configure(EntityTypeBuilder<FormulaireSatisfactionQuestionsType> builder)
        {
            builder.ToTable("FormulaireSatisfactionQuestionsTypes");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
     .ValueGeneratedOnAdd();
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
