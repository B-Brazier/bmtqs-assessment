using bmtqs_assessment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading;

namespace bmtqs_assessment.Controllers
{
    public class PagesController : Controller
    {
        private readonly ILogger<PagesController> _logger;
        private readonly IContactDatabaseService _contactDatabaseService;

        public PagesController(ILogger<PagesController> logger, 
            IContactDatabaseService contactDatabaseService)
        {
            _logger = logger;
            _contactDatabaseService = contactDatabaseService;
        }

        public IActionResult CreateContact()
        {
            return View();
        }

        public async Task<IActionResult> ViewAllContacts(CancellationToken cancellationToken)
        {
            var contacts = await _contactDatabaseService.GetContactsAsync(cancellationToken);
            return View("ViewAllContacts", contacts.ToList());
        }
    }
}
