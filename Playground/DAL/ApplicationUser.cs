using Microsoft.AspNetCore.Identity;

namespace Playground.DAL
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
