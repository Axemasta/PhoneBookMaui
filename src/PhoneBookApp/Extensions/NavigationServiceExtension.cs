using PhoneBookApp.Abstractions;
using PhoneBookApp.Helpers;
using PhoneBookApp.Models;
using PhoneBookApp.Navigation;
using System;
using System.Threading.Tasks;

namespace PhoneBookApp.Extensions
{
    public static class NavigationServiceExtension
    {
        public static async Task<INavigationService> NavigateToAddContactPage(this INavigationService navigationService)
        {
            if (navigationService is null)
            {
                throw new ArgumentNullException(nameof(navigationService));
            }

            var navParams = new NavigationParameters();

            await navigationService.NavigateAsync(NavigationHelper.ContactPage, navParams);

            return navigationService;
        }

        public static async Task<INavigationService> NavigateToContactPage(this INavigationService navigationService, Contact contact)
        {
            if (navigationService is null)
                throw new ArgumentNullException(nameof(navigationService));

            var navParams = new NavigationParameters()
            {
                { NavigationConstants.Contact, contact }
            };

            await navigationService.NavigateAsync(NavigationHelper.ContactPage, navParams);

            return navigationService;
        }
    }
}
