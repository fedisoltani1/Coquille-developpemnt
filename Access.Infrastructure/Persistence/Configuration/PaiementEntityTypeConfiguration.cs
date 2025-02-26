using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class PaiementEntityTypeConfiguration
         : IEntityTypeConfiguration<Paiement>
    {
        public void Configure(EntityTypeBuilder<Paiement> builder)
        {
            builder.ToTable("Paiements");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd();

            builder.Property(e => e.BanqueIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ChequeNumero)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ClientCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ClientIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ClientRib)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Commentaire).HasColumnType("text");
            builder.Property(e => e.CreationLe).HasColumnType("datetime");
            builder.Property(e => e.CreationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ModeReglementPaiementIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.ModificationLe).HasColumnType("datetime");
            builder.Property(e => e.ModificationPar)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Montant).HasColumnType("decimal(18, 3)");
            builder.Property(e => e.Numero)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.NumeroTransaction)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.PaiementStatutIntitule)
                .HasMaxLength(100)
                .IsUnicode(false);

        }
    }
}
