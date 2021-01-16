using Microsoft.EntityFrameworkCore;
using World.Core.DomainEntities.Cities;
using World.Core.DomainEntities.Countries;
using World.Data.EF.Config.CityConfig;
using World.Data.EF.Config.CountryConfig;

namespace World.Data.EF.Context
{
    public class WorldDbContext : DbContext
    {
        public WorldDbContext(DbContextOptions<WorldDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; private set; }
        public DbSet<City> Cities { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfig())
                        .ApplyConfiguration(new CityConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
