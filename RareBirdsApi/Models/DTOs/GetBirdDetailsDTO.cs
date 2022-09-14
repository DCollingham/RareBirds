namespace RareBirdsApi.Models.DTOs
{
    public class GETBirdDetailsDTO
    {
        public int Id { get; set; }
        public string Genus { get; set; }
        public string Species { get; set; }
        public string Rarity { get; set; }

        public List<GetSightingDTO> Sightings { get; set; }
    }
}
