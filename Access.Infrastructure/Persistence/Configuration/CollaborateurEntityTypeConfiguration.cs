using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class CollaborateurEntityTypeConfiguration
         : IEntityTypeConfiguration<Collaborateur>
    {
        public void Configure(EntityTypeBuilder<Collaborateur> builder)
        {
            builder.ToTable("Collaborateurs");
            builder.HasKey(e => e.Id).HasName("PK_Collaborateur");
            builder.Property(e => e.Id)
             .ValueGeneratedOnAdd();
            builder.Property(e => e.Adresse)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.AdresseMail)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.AgenceIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Cin)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CodePostal)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CreationLe).HasColumnType("datetime");
            builder.Property(e => e.CreationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Fonction)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Gouvernorat)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");
            builder.Property(e => e.IsExterne).HasColumnName("isExterne");
            builder.Property(e => e.ModificationLe).HasColumnType("datetime");
            builder.Property(e => e.ModificationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.NomComplet)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.RoleIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Telephone)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Ville)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.Agence).WithMany(p => p.Collaborateurs)
                .HasForeignKey(d => d.AgenceId)
                .HasConstraintName("FK_Collaborateurs_SocieteAgences").OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Role).WithMany(p => p.Collaborateurs)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Collaborateurs_CollaborateurRoles").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
