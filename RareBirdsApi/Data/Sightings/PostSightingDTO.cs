using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RareBirdsApi.Data.Sightings
{
    public class PostSightingDTO : BaseSighting
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int BirdId { get; set; }
    }
}
