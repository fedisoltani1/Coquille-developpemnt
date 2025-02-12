using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ClientTypeEntityTypeConfiguration
         : IEntityTypeConfiguration<ClientType>
    {
        public void Configure(EntityTypeBuilder<ClientType> builder)
        {
            builder.ToTable("ClientTypes");
            builder.HasKey(e => e.Id)
               ;
            builder.Property(e => e.Id)
       .ValueGeneratedOnAdd();
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");
        }
    }
}
