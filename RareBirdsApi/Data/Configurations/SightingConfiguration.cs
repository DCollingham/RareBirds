using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RareBirdsApi.Data.Models;

namespace RareBirdsApi.Models.Configurations
{
    public class SightingConfiguration : IEntityTypeConfiguration<Sighting>
    {
        public void Configure(EntityTypeBuilder<Sighting> builder)
        {
            builder.HasData(
                new Sighting
                {
                    Id = 1,
                    DateSighted = new DateTime(2022, 09, 25),
                    Longditude = 50.96093307531041,
                    Latitude = -4.163894889530649,
                    BirdId = 1
                },
                new Sighting
                {
                    Id = 2,
                    DateSighted = new DateTime(2022, 09, 15),
                    Longditude = 51.96093307531041,
                    Latitude = -5.163894889530649,
                    BirdId = 1
                }
                ); ; 
        }
    }
}
