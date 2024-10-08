using My_Login_App.API.Enums;

namespace My_Login_App.API.Models
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role {get; set; }
    }
}
