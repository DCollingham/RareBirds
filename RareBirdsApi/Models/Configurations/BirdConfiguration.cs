using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RareBirdsApi.Models.Configurations
{
    public class BirdConfiguration : IEntityTypeConfiguration<Bird>
    {
        public void Configure(EntityTypeBuilder<Bird> builder)
        {
            builder.HasData(
                new Bird
                {
                    Id = 1,
                    NickName = "Grey Patridge",
                    Genus = "Perdix",
                    Species = "Perdix",
                    Rarity = Enums.Rarity.Red,
                },

                new Bird
                {
                    Id = 2,
                    NickName = "Cuckoo",
                    Genus = "Cuculus",
                    Species = "Canorus",
                    Rarity = Enums.Rarity.Red,
                }
                );
        }
    }
}
