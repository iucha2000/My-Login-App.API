using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace My_Login_App.API.Models
{
    public class CardResponse
    {
        public int Id { get; init; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string CreateDate { get; init; }

        public string Status { get; set; }
    }
}
