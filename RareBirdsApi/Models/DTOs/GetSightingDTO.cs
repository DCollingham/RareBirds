namespace RareBirdsApi.Models.DTOs
{
    public class GetSightingDTO
    {
        public DateTime DateSighted { get; set; }
        public double Longditude { get; set; }
        public double Latitude { get; set; }
    }
}