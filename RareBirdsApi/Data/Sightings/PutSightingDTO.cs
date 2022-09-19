using System.ComponentModel.DataAnnotations;

namespace RareBirdsApi.Data.Sightings
{
    public class PutSightingDTO : BaseSighting
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        public int BirdId { get; set; }
    }
}
