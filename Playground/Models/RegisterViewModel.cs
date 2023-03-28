using System.ComponentModel.DataAnnotations;

namespace Playground.Models
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
    }
}
