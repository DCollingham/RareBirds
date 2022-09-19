using RareBirdsApi.Data.Birds;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RareBirdsApi.Data.Sightings
{
    public class Sighting : BaseSighting
    {
        public int Id { get; set; }

        [ForeignKey(nameof(BirdId))]
        public int BirdId { get; set; }
        public Bird Bird { get; set; }

    }
}
