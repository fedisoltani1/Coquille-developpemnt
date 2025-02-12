﻿using Access.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Access.Infrastructure.Persistence.Configuration
{
    public class BanqueEntityTypeConfiguration
         : IEntityTypeConfiguration<Banque>
    {
        public void Configure(EntityTypeBuilder<Banque> builder)
        {
            builder.ToTable("Banques");
            builder.HasKey(e => e.Id)
                     .HasName("Id");
            builder.Property(e => e.Id)
                         .ValueGeneratedOnAdd();
            builder.Property(e => e.Intitule)
               .HasMaxLength(100)
               .IsUnicode(false);
            builder.Property(e => e.IsActif)
                .HasDefaultValue(true)
                .HasColumnName("isActif");

        }
    }
}
