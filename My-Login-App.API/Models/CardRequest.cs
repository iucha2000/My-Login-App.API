using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace My_Login_App.API.Models
{
    public class CardRequest
    {
        [JsonRequired]
        [MaxLength(50)]
        public string Title { get; set; }

        [JsonRequired]
        [MaxLength(50)]
        public string Description { get; set; }

        [JsonRequired]
        [MaxLength(50)]
        public string Author { get; set; }

        [JsonRequired]
        [MaxLength(50)]
        public string Status { get; set; }
    }
}
