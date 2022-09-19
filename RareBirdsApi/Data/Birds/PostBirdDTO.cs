using System.ComponentModel.DataAnnotations;

namespace RareBirdsApi.Data.Birds
{
    public class PostBirdDTO : BaseBird
    {
        public string NickName { get; set; }
    }
}
