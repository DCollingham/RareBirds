using System.ComponentModel.DataAnnotations;

namespace RareBirdsApi.Models.DTOs
{
    public class PostBirdDTO
    {
        [Required]
        public string Genus { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Rarity { get; set; }
    }
}
