using bmtqs_assessment.Models;
using bmtqs_assessment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bmtqs_assessment.Controllers;

public class ContactController : Controller
{
    private readonly IContactDatabaseService _contactDatabaseService;

    public ContactController(
        IContactDatabaseService contactDatabaseService)
    {
        _contactDatabaseService = contactDatabaseService ?? throw new ArgumentNullException(nameof(contactDatabaseService));
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(ContactModel model, CancellationToken cancellationToken)
    {
        await _contactDatabaseService.CreateNewContactAsync(model, cancellationToken);
        return RedirectToAction("ViewAllContacts", "Pages");
    }

    [HttpPost]
    public async Task<IActionResult> SoftDeleteContact(ContactModel model, CancellationToken cancellationToken)
    {
        await _contactDatabaseService.SoftDeleteContactAsync(model, cancellationToken);
        return RedirectToAction("ViewAllContacts", "Pages");
    }
}
