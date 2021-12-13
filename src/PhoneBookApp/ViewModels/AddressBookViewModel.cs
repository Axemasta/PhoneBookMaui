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
        private readonly IContactRepository _contactRepository;
        private readonly INavigationService _navigationService;

        public ObservableCollection<Contact> Contacts { get; }

        public ICommand AddContactCommand { get; }

        public Command<Contact> ContactSelectedCommand { get; }

        public AddressBookViewModel(INavigationService navigationService, IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _navigationService = navigationService;

            Title = "Address Book";

            var contacts = _contactRepository.GetContacts();

            Contacts = new ObservableCollection<Contact>(contacts);

            AddContactCommand = new Command(OnAddContact);

            ContactSelectedCommand = new Command<Contact>(OnContactSelected);
        }

        async void OnAddContact()
        {
            // TODO
            await _navigationService.NavigateToAddContactPage();
        }

        async void OnContactSelected(Contact contact)
        {
            await _navigationService.NavigateToContactPage(contact);
        }
    }
}
