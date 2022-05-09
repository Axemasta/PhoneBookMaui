using PhoneBookApp.Abstractions;
using PhoneBookApp.Pages;
using PhoneBookApp.Repositories;
using PhoneBookApp.ViewModels;
using Prism;
using Prism.Ioc;
using Prism.Navigation;

namespace PhoneBookApp
{
    public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UsePrismApp<App>()
				.RegisterTypes(containerRegistry =>
                {
					// Services
					containerRegistry.Register<IContactItemRepository, MockContactItemRepository>();

					// Pages
					containerRegistry.RegisterForNavigation<NavigationPage>();
					containerRegistry.RegisterForNavigation<AddressBookPage, AddressBookViewModel>();
					containerRegistry.RegisterForNavigation<ContactPage, ContactViewModel>();
				})
				.OnAppStart(async navigationService =>
                {
					var nav = await navigationService.NavigateAsync("NavigationPage/AddressBookPage");

					if (!nav.Success)
					{
						System.Diagnostics.Debugger.Break();
					}
				})
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			return builder.Build();
		}
	}
}