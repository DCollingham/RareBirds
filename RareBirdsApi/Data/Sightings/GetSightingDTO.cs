using System.ComponentModel.DataAnnotations;

namespace RareBirdsApi.Data.Sightings
{
    public class GetSightingDTO : BaseSighting
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int BirdId { get; set; }
    }
}