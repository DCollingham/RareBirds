using RareBirdsApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RareBirdsApi.Data.Birds
{
    public abstract class BaseBird
    {
        [Required]
        [StringLength(75)]
        public string Genus { get; set; }
        [Required]
        [StringLength(75)]
        public string Species { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(24)")]
        public Rarity Rarity { get; set; }
    }
}
