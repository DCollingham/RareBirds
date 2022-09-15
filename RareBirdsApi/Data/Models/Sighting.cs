using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RareBirdsApi.Data.Models
{
    public class Sighting
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateSighted { get; set; }
        public double Longditude { get; set; }
        public double Latitude { get; set; }

        [ForeignKey(nameof(BirdId))]
        public int BirdId { get; set; }
        public Bird Bird { get; set; }

    }
}
