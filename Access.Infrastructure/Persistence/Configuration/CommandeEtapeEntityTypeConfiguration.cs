using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class CommandeEtapeEntityTypeConfiguration
         : IEntityTypeConfiguration<CommandeEtape>
    {
        public void Configure(EntityTypeBuilder<CommandeEtape> builder)
        {
            builder.ToTable("CommandeEtapes");
            builder.HasKey(e => e.Id).HasName("PK_CommandeEtape");
            builder.Property(e => e.Id)
      .ValueGeneratedOnAdd();
            builder.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CommandeStautIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IsAfficheClient)
                .HasDefaultValue(true)
                .HasColumnName("isAfficheClient");
        }
    }
}
