using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Access.Infrastructure.Persistence.Configuration
{
    public class FormulaireSatisfactionQuestionEntityTypeConfiguration
         : IEntityTypeConfiguration<FormulaireSatisfactionQuestion>
    {
        public void Configure(EntityTypeBuilder<FormulaireSatisfactionQuestion> builder)
        {
            builder.ToTable("FormulaireSatisfactionQuestions");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
      .ValueGeneratedOnAdd();
            builder.Property(e => e.Question).HasColumnType("text");
        }
    }
}
