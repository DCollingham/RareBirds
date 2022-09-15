using System.ComponentModel.DataAnnotations;

namespace RareBirdsApi.Models.DTOs
{
    public abstract class BaseBirdDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Genus { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Rarity { get; set; }
    }
}
