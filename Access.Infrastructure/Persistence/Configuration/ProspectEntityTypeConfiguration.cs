using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ProspectEntityTypeConfiguration
         : IEntityTypeConfiguration<Prospect>
    {
        public void Configure(EntityTypeBuilder<Prospect> builder)
        {
            builder.ToTable("Prospects");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                     .ValueGeneratedOnAdd();
            builder.Property(e => e.Abreviation)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Adresse)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.AdresseMail)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CodePostal)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CreationLe).HasColumnType("datetime");
            builder.Property(e => e.CreationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Gouvernorat)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Intitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.MatriculeFiscaleCin)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.NomCommercial)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.NomPremierResponsable)
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
