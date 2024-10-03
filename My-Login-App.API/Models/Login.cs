using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace My_Login_App.API.Models
{
    public class Login
    {
        [JsonRequired]
        [MaxLength(50)]
        public string Username { get; set; }

        [JsonRequired]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
