using PhoneBookApp.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Domain.Validators
{
    public class ContactItemValidator : IContactItemValidator
    {
        public bool ContactItemHasChanged(IContactItem originalItem, IContactItem comparisonItem)
        {
            throw new NotImplementedException();
        }

        public bool ContactItemIsComplete(IContactItem contactItem)
        {
            throw new NotImplementedException();
        }
    }
}
