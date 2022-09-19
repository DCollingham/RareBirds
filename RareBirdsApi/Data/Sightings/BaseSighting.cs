using System.ComponentModel.DataAnnotations;

namespace RareBirdsApi.Data.Sightings
{
    public abstract class BaseSighting
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateSighted { get; set; }
        public double Longditude { get; set; }
        public double Latitude { get; set; }
    }
}
