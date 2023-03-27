using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Playground.DAL;
using Playground.Models;
using Playground.Services;
using System.Runtime.CompilerServices;

namespace Playground.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserService _userService;
        private readonly string _failedRegister = "Failed to Register";
        private readonly string _failedLogin = "Failed to Login";

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // If User is Authenticated Redirect to Home Page
            if(User.Identity != null && User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model) 
        {
            if (!ModelState.IsValid)
                return View(model);

            var Result = await _userService.Login(model.Email, model.Password);

            if(!Result)
            {
                ModelState.AddModelError("", _failedLogin);
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            // If user is Authenticated Redirect to Home Page
            if (User.Identity != null && User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) 
        {
            if (!ModelState.IsValid)
                return View(model);

            var Result = await _userService.Register(model.Username, model.Email, model.Password);

            if(!Result)
            {
                ModelState.AddModelError("", _failedRegister);
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
