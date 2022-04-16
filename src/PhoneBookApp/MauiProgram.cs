using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using PhoneBookApp.Abstractions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PhoneBookApp.Repositories;
using PhoneBookApp.Services;
using PhoneBookApp.ViewModels;

namespace PhoneBookApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			var services = builder.Services;

			services.TryAddTransient<IContactItemRepository, MockContactItemRepository>();
			services.TryAddSingleton<INavigationService, NavigationService>();

			return builder.Build();
		}
	}
}