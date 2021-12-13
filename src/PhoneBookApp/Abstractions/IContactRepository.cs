using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Abstractions
{
    public interface IContactRepository
    {
        List<Contact> GetContacts();
    }
}
