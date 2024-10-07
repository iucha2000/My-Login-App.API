using My_Login_App.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace My_Login_App.API.Models
{
    public class User
    {
        private Role _role;

        [JsonRequired]
        [MaxLength(50)]
        public string Email { get; set; }

        [JsonRequired]
        [MaxLength(50)]
        public string Username { get; set; }

        [JsonRequired]
        [MaxLength(50)]
        public string Password { get; set; }

        [JsonRequired]
        public Role Role
        {
            get { return _role; }
            set
            {
                if (value != Role.User && value != Role.Admin)
                {
                    _role = Role.User;
                }
                else
                {
                    _role = value;
                }
            }
        }
    }
}
