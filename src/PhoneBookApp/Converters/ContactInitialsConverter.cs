using Microsoft.Maui.Controls;
using PhoneBookApp.Models;
using System;
using System.Globalization;
using System.Linq;

namespace PhoneBookApp.Converters
{
    public class ContactInitialsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            if (value is not Contact contact)
            {
                throw new NotSupportedException($"Value must be of type {nameof(Contact)}");
            }

            string initals = string.Empty;

            if (!string.IsNullOrEmpty(contact.FirstName))
            {
                initals += contact.FirstName.FirstOrDefault();
            }

            if (!string.IsNullOrEmpty(contact.LastName))
            {
                initals += contact?.LastName.FirstOrDefault();
            }

            return initals.ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
