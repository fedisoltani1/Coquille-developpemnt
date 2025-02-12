using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ConsoleStatutEntityTypeConfiguration
         : IEntityTypeConfiguration<ConsoleStatut>
    {
        public void Configure(EntityTypeBuilder<ConsoleStatut> builder)
        {
            builder.ToTable("ConsoleStatuts");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
      .ValueGeneratedOnAdd();
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
