using PhoneBookApp.Models;

namespace PhoneBookApp.Abstractions
{
    public interface IContactItemRepository
    {
        List<ContactItem> GetContacts();
    }
}
