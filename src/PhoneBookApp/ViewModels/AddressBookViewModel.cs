using Ardalis.GuardClauses;
using Microsoft.Maui.Controls;
using PhoneBookApp.Abstractions;
using PhoneBookApp.Extensions;
using PhoneBookApp.Helpers;
using PhoneBookApp.Models;
using PhoneBookApp.Navigation;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PhoneBookApp.ViewModels
{
    public class AddressBookViewModel : ViewModelBase
    {
        private readonly IContactItemRepository _contactRepository;

        public ObservableCollection<ContactItem> Contacts { get; }

        public ICommand AddContactCommand { get; }

        public DelegateCommand<ContactItem> ContactSelectedCommand { get; }

        public AddressBookViewModel(INavigationService navigationService, IContactItemRepository contactRepository)
            : base(navigationService)
        {
            _contactRepository = Guard.Against.Null(contactRepository, nameof(contactRepository));

            Title = "Address Book";

            var contacts = _contactRepository.GetContacts()
                .OrderBy(c => c.LastName);

            Contacts = new ObservableCollection<ContactItem>(contacts);

            AddContactCommand = new DelegateCommand(OnAddContact);

            ContactSelectedCommand = new DelegateCommand<ContactItem>(OnContactSelected);
        }

        async void OnAddContact()
        {
            // TODO
            await navigationService.NavigateAsync(NavigationHelper.ContactPage);
        }

        async void OnContactSelected(ContactItem contact)
        {
            var navParams = new NavigationParameters()
            {
                { NavigationConstants.Contact, contact }
            };

            var nav = await navigationService.NavigateAsync(NavigationHelper.ContactPage, navParams);

            if (!nav.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
    }
}
