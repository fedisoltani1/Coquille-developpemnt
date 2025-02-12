using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class FormulaireSatisfactionReponseEntityTypeConfiguration
         : IEntityTypeConfiguration<FormulaireSatisfactionReponse>
    {
        public void Configure(EntityTypeBuilder<FormulaireSatisfactionReponse> builder)
        {
            builder.ToTable("FormulaireSatisfactionReponses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
     .ValueGeneratedOnAdd();
            builder.Property(e => e.FormulaireSatisfactionQuestion).HasColumnType("text");
            builder.Property(e => e.Reponse).HasColumnType("text");
        }
    }
}
