using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ChequeEntityTypeConfiguration
         : IEntityTypeConfiguration<Cheque>
    {
        public void Configure(EntityTypeBuilder<Cheque> builder)
        {
            builder.ToTable("Cheques");
            builder.HasKey(e => e.Id)
                     .HasName("Id");
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(e => e.ChequeStatutId)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");
            builder.Property(e => e.Numero)
                .HasMaxLength(100)
                .IsUnicode(false);
          
            builder.HasOne(d => d.ChequeStatut).WithMany(p => p.Cheques)
               .HasForeignKey(d => d.ChequeStatutId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Cheques_ChequeStatuts");

            builder.HasOne(d => d.Banque)
                .WithMany(p => p.Cheques) 
                .HasForeignKey(d => d.BanqueId) 
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Cheques_Banques");
            builder.HasOne(d => d.Chequier)
               .WithMany(p => p.Cheques)
               .HasForeignKey(d => d.ChequierId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Cheques_Chequiers");
        }
    }
}
