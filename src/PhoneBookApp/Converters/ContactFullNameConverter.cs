using Microsoft.Maui.Controls;
using PhoneBookApp.Extensions;
using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Converters
{
    public class ContactFullNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return null;
            }

            if (value is not ContactItem contact)
            {
                throw new NotSupportedException($"Value must be of type {nameof(Contact)}");
            }

            return contact.GetFullName();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
