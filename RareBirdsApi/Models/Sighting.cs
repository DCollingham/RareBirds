using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RareBirdsApi.Models
{
    public class Sighting
    {
        public int Id { get; set; }
        public DateTime DateSighted { get; set; }
        public double Longditude { get; set; }
        public double Latitude { get; set; }

        [ForeignKey(nameof(BirdId))]
        public int BirdId { get; set; }
        public Bird Bird { get; set; }

    }
}
