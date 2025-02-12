using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ClientEntityTypeConfiguration
         : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(e => e.Id).HasName("PK_Client");
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
            builder.Property(e => e.Classe)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("C");
            builder.Property(e => e.ClientTypeIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ClientWarehouseIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CodePostal)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CollaborateurName)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CreationLe).HasColumnType("datetime");
            builder.Property(e => e.CreationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.FacturationCategorieIntitule)
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
            builder.Property(e => e.IsAssujettiTpf)
                .HasDefaultValue(true)
                .HasColumnName("isAssujettiTpf");
            builder.Property(e => e.IsAssujettiTva)
                .HasDefaultValue(true)
                .HasColumnName("isAssujettiTva");
            builder.Property(e => e.IsFacture)
                .HasDefaultValue(true)
                .HasColumnName("isFacture");
            builder.Property(e => e.IsGenerationBonLivraison).HasColumnName("isGenerationBonLivraison");
            builder.Property(e => e.IsStatFacturation)
                .HasDefaultValue(true)
                .HasColumnName("isStatFacturation");
            builder.Property(e => e.IsStatPayout)
                .HasDefaultValue(true)
                .HasColumnName("isStatPayout");
            builder.Property(e => e.MatriculeFiscaleCin)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ModeReglementFacturationIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ModeReglementPaimentIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ModificationLe).HasColumnType("datetime");
            builder.Property(e => e.ModificationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.NomCommercial)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.NomPremierResponsable)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.NombreTentativeLivraison).HasDefaultValue(3);
            builder.Property(e => e.ServiceInitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Telephone)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Ville)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.ClientInfo).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Clients_Clients");

            builder.HasOne(d => d.ClientType).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ClientTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_ClientTypes");

            builder.HasOne(d => d.ClientWarehouse).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ClientWarehouseId)
                .HasConstraintName("FK_Clients_ClientWarehouses");

            builder.HasOne(d => d.Collaborateur).WithMany(p => p.Clients)
                .HasForeignKey(d => d.CollaborateurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_Collaborateurs");

            builder.HasOne(d => d.FacturationCategorie).WithMany(p => p.Clients)
                .HasForeignKey(d => d.FacturationCategorieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_FacturationCategories");

            builder.HasOne(d => d.ModeReglementFacturation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ModeReglementFacturationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_ModesReglementFacturation");

            builder.HasOne(d => d.ModeReglementPaiment).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ModeReglementPaimentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_ModesReglementPaiement");

            builder.HasOne(d => d.Service).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_Services");
        }
    }
}
