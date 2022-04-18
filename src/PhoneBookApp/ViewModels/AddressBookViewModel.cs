using Microsoft.Maui.Controls;
using PhoneBookApp.Abstractions;
using PhoneBookApp.Extensions;
using PhoneBookApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PhoneBookApp.ViewModels
{
    public class AddressBookViewModel : ViewModelBase
    {
        private readonly IContactItemRepository _contactRepository;
        private readonly INavigationService _navigationService;

        public ObservableCollection<ContactItem> Contacts { get; }

        public ICommand AddContactCommand { get; }

        public Command<ContactItem> ContactSelectedCommand { get; }

        public AddressBookViewModel(INavigationService navigationService, IContactItemRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _navigationService = navigationService;

            Title = "Address Book";

            var contacts = _contactRepository.GetContacts()
                .OrderBy(c => c.LastName);

            Contacts = new ObservableCollection<ContactItem>(contacts);

            AddContactCommand = new Command(OnAddContact);

            ContactSelectedCommand = new Command<ContactItem>(OnContactSelected);
        }

        async void OnAddContact()
        {
            // TODO
            await _navigationService.NavigateToAddContactPage();
        }

        async void OnContactSelected(ContactItem contact)
        {
            await _navigationService.NavigateToContactPage(contact);
        }
    }
}
