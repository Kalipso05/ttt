using System.ComponentModel.DataAnnotations;

namespace RoadsOfRussiaWeb.Models
{
    public class UserLoginRequest
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
