using System.Diagnostics;
using bmtqs_assessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace bmtqs_assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Naviagate to index page
        public IActionResult Index()
        {
            return View();
        }

        // Navigate to error page, note I've not done anything to change this.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
