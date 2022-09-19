using Newtonsoft.Json;
using RareBirdsApi.Data.Sightings;
using RareBirdsApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RareBirdsApi.Data.Birds
{
    public class Bird : BaseBird
    {
        [Required]
        public int Id { get; set; }
        public string NickName { get; set; }   
        public virtual IList<Sighting> Sightings { get; set; }
    }
}
