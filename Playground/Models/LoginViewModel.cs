using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Playground.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "The password failed")]
        public string Password { get; set; }
    }
}
