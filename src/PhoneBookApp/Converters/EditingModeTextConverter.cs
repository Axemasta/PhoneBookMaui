using PhoneBookApp.Enums;
using PhoneBookApp.Resources.Localization;
using System.Globalization;

namespace PhoneBookApp.Converters
{
    public class EditingModeTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return null;
            }

            if (value is not EditingMode mode)
            {
                throw new NotSupportedException($"Value is of unsupported type {value.GetType()}, expected type {nameof(EditingMode)}");
            }

            return mode switch
            {
                EditingMode.Add => PhonebookAppResources.ContactPage_SaveButtonText,
                EditingMode.Edit => PhonebookAppResources.ContactPage_EditButtonText,
                _ => throw new InvalidOperationException($"Invalid editing mode: {mode}"),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
