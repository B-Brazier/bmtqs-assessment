using bmtqs_assessment.Models;
using bmtqs_assessment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        // Navigate to Create Contact view
        public IActionResult CreateContact()
        {
            return View();
        }

        // Navigate to Update Contact view
        public IActionResult UpdateContact(int id, string firstName, string lastName, string companyName, string mobileNumber, string emailAddress)
        {
            ContactModel model = new ContactModel
            {
                ContactID = id,
                FirstName = firstName,
                LastName = lastName,
                CompanyName = companyName,
                MobileNumber = mobileNumber,
                EmailAddress = emailAddress
            };
            return View("UpdateContact", model);
        }

        // Navigate to Delete Contact view
        public IActionResult DeleteContact(int id, string firstName, string lastName, string companyName, string mobileNumber, string emailAddress)
        {
            ContactModel model = new ContactModel
            {
                ContactID = id,
                FirstName = firstName,
                LastName = lastName,
                CompanyName = companyName,
                MobileNumber = mobileNumber,
                EmailAddress = emailAddress
            };
            return View("DeleteContact", model);
        }

        // Navigate to View all contacts view and add records
        public async Task<IActionResult> ViewAllContacts(CancellationToken cancellationToken)
        {
            var contacts = await _contactDatabaseService.GetContactsAsync(cancellationToken);
            return View("ViewAllContacts", contacts.ToList());
        }
    }
}
