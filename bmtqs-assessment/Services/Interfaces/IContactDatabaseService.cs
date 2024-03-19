using bmtqs_assessment.Models;

namespace bmtqs_assessment.Services.Interfaces;

public interface IContactDatabaseService
{
    Task<List<ContactModel>> GetContactsAsync(CancellationToken cancellationToken);
    Task CreateNewContactAsync(ContactModel contact, CancellationToken cancellationToken);
    Task UpdateContactAsync(ContactModel contact, CancellationToken cancellationToken);
    Task SoftDeleteContactAsync(ContactModel contact, CancellationToken cancellationToken);
}
