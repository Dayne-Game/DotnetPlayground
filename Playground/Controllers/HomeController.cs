using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Playground.Models;
using System.Diagnostics;

namespace Playground.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            
            return View();
        }

        public IActionResult About()
        {
            var model = new AboutViewModel();

            model.Title = "About us";
            model.Description = "Decription.";

            model.Tags = new List<string>();
            model.Tags.Add("Tag 1");
            model.Tags.Add("Tag 1");
            model.Tags.Add("Tag 1");
            model.Tags.Add("Tag 1");

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}