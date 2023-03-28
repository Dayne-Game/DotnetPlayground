using Microsoft.AspNetCore.Identity;
using Playground.DAL;

namespace Playground.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Register(string username, string firstname, string lastname, string email, string password)
        {
            try
            {
                // Check if email and Username is already taken
                var exisitngUsername = await _userManager.FindByNameAsync(username);
                var exisitngEmail = await _userManager.FindByEmailAsync(email);

                if (exisitngEmail != null)
                    return false;

                var User = new ApplicationUser
                {
                    UserName = username,
                    Firstname = firstname,
                    Lastname = lastname,
                    Email = email,
                    EmailConfirmed = true
                };

                var Result = await _userManager.CreateAsync(User, password);

                return Result.Succeeded;
            }
            catch (Exception)
            {
                // TO DO: Add Logging :-)
                return false;
            }
        }

        public async Task<bool> Login(string email, string password)
        {
            try
            {
                var User = await _userManager.FindByEmailAsync(email);

                if(User == null)
                    return false;

                var Result = await _signInManager.PasswordSignInAsync(User, password, isPersistent: false, lockoutOnFailure: false);

                return Result.Succeeded;
            }
            catch (Exception)
            {
                // TO DO: Add Logging :-)
                return false;
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
