using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Extensions
{
    public static class ContactExtension
    {
        public static string GetFullName(this Contact contact)
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
