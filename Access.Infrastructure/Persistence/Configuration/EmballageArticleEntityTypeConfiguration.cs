using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Console = Access.AppCore.Entities.Console;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class EmballageArticleEntityTypeConfiguration
         : IEntityTypeConfiguration<EmballageArticle>
    {
        public void Configure(EntityTypeBuilder<EmballageArticle> builder)
        {
            builder.ToTable("EmballageArticles");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
      .ValueGeneratedOnAdd();
            builder.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");
        }
    }
}
