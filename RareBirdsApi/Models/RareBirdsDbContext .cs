using Microsoft.EntityFrameworkCore;
using RareBirdsApi.Models.Configurations;

namespace RareBirdsApi.Models
{
    public class RareBirdsDbContext : DbContext
    {
        public RareBirdsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bird> Birds {get;set;}
        public DbSet<Sighting> Sightings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BirdConfiguration());
            modelBuilder.ApplyConfiguration(new SightingConfiguration());
        }
    }
}
