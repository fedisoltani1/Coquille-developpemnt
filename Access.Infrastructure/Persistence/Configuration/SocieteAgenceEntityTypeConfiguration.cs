using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class SocieteAgenceEntityTypeConfiguration
         : IEntityTypeConfiguration<SocieteAgence>
    {
        public void Configure(EntityTypeBuilder<SocieteAgence> builder)
        {
            builder.ToTable("SocieteAgences");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            builder.Property(e => e.Adresse)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.AdresseMail)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CodePostal)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ResponsableName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ResponsableTel)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.ResponsableEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Gouvernorat)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");
            builder.Property(e => e.MatriculeFiscale)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Telephone)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Ville)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
