using RareBirdsApi.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RareBirdsApi.Models
{
    public class Bird
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Genus { get; set; }
        public string Species { get; set; }
        
        [Column(TypeName = "nvarchar(24)")]
        public Rarity Rarity { get; set; }
    }
}
