using PhoneBookApp.Abstractions;
using PhoneBookApp.Pages;
using PhoneBookApp.ViewModels;
using Application = Microsoft.Maui.Controls.Application;

namespace PhoneBookApp
{
    public partial class App : Application
	{
		public App(INavigationService navigationService, IContactItemRepository	contactRepository)
		{
            InitializeComponent();

			var addressBookViewModel = new AddressBookViewModel(navigationService, contactRepository);

			var addressBookPage = new AddressBookPage()
            {
				BindingContext = addressBookViewModel
            };

			MainPage = new NavigationPage(addressBookPage);
		}
	}
}
