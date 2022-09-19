using System.ComponentModel.DataAnnotations;

namespace RareBirdsApi.Data.Birds
{
    public class PutBirdDTO : BaseBird
    {
        [Required]
        public int Id { get; set; }
        public string NickName { get; set; }
    }
}
