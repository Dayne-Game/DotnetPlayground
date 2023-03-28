using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Playground.Services
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Register(string username, string email, string password)
        {
            try
            {
                // Check if email and Username is already taken
                var exisitngUsername = await _userManager.FindByNameAsync(username);
                var exisitngEmail = await _userManager.FindByEmailAsync(email);

                if (exisitngEmail != null)
                    return false;

                var User = new IdentityUser
                {
                    UserName = username,
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
