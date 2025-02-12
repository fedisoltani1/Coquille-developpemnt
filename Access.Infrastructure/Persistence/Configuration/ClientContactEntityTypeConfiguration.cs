using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class ClientContactEntityTypeConfiguration
         : IEntityTypeConfiguration<ClientContact>
    {
        public void Configure(EntityTypeBuilder<ClientContact> builder)
        {
            builder.ToTable("ClientContacts");
            builder.HasKey(e => e.Id)
                     .HasName("PK_ClientContact");
            builder.Property(e => e.Id)
                 .ValueGeneratedOnAdd();
            builder.Property(e => e.AdresseMail)
                  .HasMaxLength(100)
                  .IsUnicode(false);
            builder.Property(e => e.Fonction)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.NomComplet)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Note).IsUnicode(false);
            builder.Property(e => e.Telephone)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.HasOne(d => d.Client).WithMany(p => p.ClientContacts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientContacts_Clients");
        }
    }
}
