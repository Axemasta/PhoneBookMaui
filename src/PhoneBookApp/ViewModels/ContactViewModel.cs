using PhoneBookApp.Enums;
using PhoneBookApp.Extensions;
using PhoneBookApp.Models;
using PhoneBookApp.Navigation;
using Prism.Navigation;
using System.Windows.Input;

namespace PhoneBookApp.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        private ContactItem _contact;
        public ContactItem Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }

        private EditingMode? _mode;
        public EditingMode? Mode
        {
            get => _mode;
            set
            {
                if (SetProperty(ref _mode, value) && value.HasValue)
                {
                    Title = GetTitleForMode(value.Value);
                }
            }
        }

        public ICommand SaveCommand { get; }

        public ContactViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Contact Page";

            SaveCommand = new Command(OnSave);
        }

        private void OnSave()
        {

        }

        public override void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(NavigationConstants.Contact, out ContactItem contact))
            {
                Contact = contact;
                Mode = EditingMode.Edit;
            }
            else
            {
                Mode = EditingMode.Add;
            }
        }

        private string GetTitleForMode(EditingMode mode)
        {
            switch (mode)
            {
                case EditingMode.Add:
                    return "Add New Contact";

                case EditingMode.Edit:
                    return _contact.GetFullName();

                default:
                    throw new NotSupportedException($"No implementation for mode: {mode}");
            }
        }
    }
}
