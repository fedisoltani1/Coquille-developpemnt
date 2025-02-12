using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ChequierStatutEntityTypeConfiguration
         : IEntityTypeConfiguration<ChequierStatut>
    {
        public void Configure(EntityTypeBuilder<ChequierStatut> builder)
        {
            builder.ToTable("ChequierStatuts");
            builder.HasKey(e => e.Id)
                     .HasName("Id");
            builder.Property(e => e.Id)
       .ValueGeneratedOnAdd();
            builder.Property(e => e.Intitule)
                 .HasMaxLength(100)
                 .IsUnicode(false);
        }
    }
}
