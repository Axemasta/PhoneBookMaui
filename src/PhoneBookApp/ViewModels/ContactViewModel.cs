using PhoneBookApp.Abstractions;
using PhoneBookApp.Extensions;
using PhoneBookApp.Models;
using PhoneBookApp.Navigation;
using System.Windows.Input;

namespace PhoneBookApp.ViewModels
{
    public class ContactViewModel : ViewModelBase, IInitialize
    {
        private readonly INavigationService _navigationService;

        private ContactItem _contact;
        public ContactItem Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }

        private ContactViewModelMode? _mode;
        public ContactViewModelMode? Mode
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

        public enum ContactViewModelMode
        {
            Add,
            Edit
        }

        public ContactViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Title = "Contact Page";

            SaveCommand = new Command(OnSave);
        }

        private void OnSave()
        {

        }

        public void Initialize(INavigationParameters navigationParameters)
        {
            if (navigationParameters.TryGetValue(NavigationConstants.Contact, out ContactItem contact))
            {
                Contact = contact;
                Mode = ContactViewModelMode.Edit;
            }
            else
            {
                Mode = ContactViewModelMode.Add;
            }
        }

        private string GetTitleForMode(ContactViewModelMode mode)
        {
            switch (mode)
            {
                case ContactViewModelMode.Add:
                    return "Add New Contact";

                case ContactViewModelMode.Edit:
                    return _contact.GetFullName();

                default:
                    throw new NotSupportedException($"No implementation for mode: {mode}");
            }
        }
    }
}
