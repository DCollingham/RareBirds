using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RareBirdsApi.Data.Birds;
using RareBirdsApi.Data.Configurations;
using RareBirdsApi.Data.Sightings;
using RareBirdsApi.Models.Configurations;

namespace RareBirdsApi.Models
{
    public class RareBirdsDbContext : IdentityDbContext<IdentityUser>
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
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
