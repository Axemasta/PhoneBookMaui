using PhoneBookApp.Models;
using System.Globalization;

namespace PhoneBookApp.Converters
{
    public class ContactInitialsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            if (value is not ContactItem contact)
            {
                throw new NotSupportedException($"Value must be of type {nameof(ContactItem)}");
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
