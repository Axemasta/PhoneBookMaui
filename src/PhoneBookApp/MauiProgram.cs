using PhoneBookApp.Abstractions;
using PhoneBookApp.Pages;
using PhoneBookApp.Repositories;
using PhoneBookApp.ViewModels;
using Prism.Ioc;

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
				.MauiBuilder
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			return builder.Build();
		}
	}
}