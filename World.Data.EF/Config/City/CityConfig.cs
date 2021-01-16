using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using World.Core.DomainEntities.Cities;

namespace World.Data.EF.Config.CityConfig
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Name).HasMaxLength(100);
            builder.HasOne(city => city.Country);
        }
    }
}
