using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using World.Core.DomainEntities.Countries;

namespace World.Data.EF.Config.CountryConfig
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(C => C.Id);
            builder.Property(c => c.Name).IsRequired();
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Name).HasMaxLength(100);
            builder.HasMany(c => c.Cities);
        }
    }
}
