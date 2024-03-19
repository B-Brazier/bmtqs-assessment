using Microsoft.AspNetCore.Mvc;

namespace bmtqs_assessment.Controllers
{
    public class PagesController : Controller
    {
        private readonly ILogger<PagesController> _logger;

        public PagesController(ILogger<PagesController> logger)
        {
            _logger = logger;
        }

        public IActionResult CreateContact()
        {
            return View();
        }

        public IActionResult ViewAllContacts()
        {
            return View();
        }
    }
}
