using PhoneBookApp.Models;

namespace PhoneBookApp.Extensions
{
    public static class ContactItemExtension
    {
        public static string GetFullName(this ContactItem contact)
        {
            if (contact is null)
                throw new ArgumentNullException(nameof(contact));

            var components = new List<string>();

            if (!string.IsNullOrEmpty(contact.FirstName))
            { 
                components.Add(contact.FirstName);
            }

            if (!string.IsNullOrEmpty(contact.LastName))
            {
                components.Add(contact.LastName);
            }

            return string.Join(" ", components);
        }
    }
}
