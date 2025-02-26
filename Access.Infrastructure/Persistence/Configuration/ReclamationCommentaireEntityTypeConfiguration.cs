using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ReclamationCommentaireEntityTypeConfiguration
         : IEntityTypeConfiguration<ReclamationCommentaire>
    {
        public void Configure(EntityTypeBuilder<ReclamationCommentaire> builder)
        {
            builder.ToTable("ReclamationCommentaires");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                 .ValueGeneratedOnAdd();
            builder.Property(e => e.CreationLe)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CreationPar).HasColumnType("datetime");
            builder.Property(e => e.Message).HasColumnType("text");

        }
    }
}
