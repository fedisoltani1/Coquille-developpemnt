using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ClientWarehouseEntityTypeConfiguration
         : IEntityTypeConfiguration<ClientWarehouse>
    {
        public void Configure(EntityTypeBuilder<ClientWarehouse> builder)
        {
            builder.ToTable("ClientWarehouses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
       .ValueGeneratedOnAdd();
            builder.Property(e => e.Intitule)
               .HasMaxLength(100)
               .IsUnicode(false);
        }
    }
}
