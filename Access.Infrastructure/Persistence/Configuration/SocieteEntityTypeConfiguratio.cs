using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class SocieteEntityTypeConfiguration : IEntityTypeConfiguration<Societe>
    {
        public void Configure(EntityTypeBuilder<Societe> builder)
        {
            builder.ToTable("Societe");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                        .ValueGeneratedOnAdd();
            builder.Property(e => e.Activite)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Adresse)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.AdresseMail)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.CodePostal)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Gouvernorat)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.MatriculeFiscale)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NomCommercial)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PremierResponsable)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.RaisonSocial)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.RegistreCommerce)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Secteur)
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
