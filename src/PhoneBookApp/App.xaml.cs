using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using PhoneBookApp.Abstractions;
using PhoneBookApp.Pages;
using PhoneBookApp.Repositories;
using PhoneBookApp.Services;
using PhoneBookApp.ViewModels;
using Application = Microsoft.Maui.Controls.Application;

namespace PhoneBookApp
{
	public partial class App : Application
	{
		public App(INavigationService navigationService, IContactRepository	contactRepository)
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
