

using RareBirdsApi.Data.Sightings;

namespace RareBirdsApi.Data.Birds
{
    public class GetBirdDetailsDTO : BaseBird
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public List<GetSightingDTO> Sightings { get; set; }
    }
}
