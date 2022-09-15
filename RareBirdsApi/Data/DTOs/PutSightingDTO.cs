using System.ComponentModel.DataAnnotations;

namespace RareBirdsApi.Models.DTOs
{
    public class PutSightingDTO
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateSighted { get; set; }
        public double Longditude { get; set; }
        public double Latitude { get; set; }
        public int BirdId { get; set; }
    }
}
