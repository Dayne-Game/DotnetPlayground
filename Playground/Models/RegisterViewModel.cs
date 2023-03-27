using System.ComponentModel.DataAnnotations;

namespace Playground.Models
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string Username { get; set; }
    }
}
