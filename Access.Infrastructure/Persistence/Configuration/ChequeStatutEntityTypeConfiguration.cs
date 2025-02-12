using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ChequeStatutEntityTypeConfiguration
         : IEntityTypeConfiguration<ChequeStatut>
    {
        public void Configure(EntityTypeBuilder<ChequeStatut> builder)
        {
            builder.ToTable("ChequeStatuts");
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
