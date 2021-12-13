using Microsoft.Maui.Controls;
using PhoneBookApp.Abstractions;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PhoneBookApp.Services
{
    public class NavigationService : INavigationService
    {
        public async Task GoBackAsync()
        {
            var currentPage = App.Current.MainPage;

            if (currentPage is null)
            {
                throw new Exception("Could not find main page");
            }

            await currentPage.Navigation.PopAsync();
        }

        public async Task NavigateAsync(string pageName)
        {
            var currentPage = App.Current.MainPage;

            if (currentPage is null)
            {
                throw new Exception("Could not find main page");
            }

            var assembly = Assembly.GetExecutingAssembly();

            if (assembly is null)
            {
                throw new Exception("Could not get current assembly");
            }

            var pageType = assembly.GetType(pageName);

            if (pageType is null)
            {
                throw new Exception($"Could not find type for name: {pageName}");
            }

            var viewModelTypeString = pageName.Replace("Page", "ViewModel");

            var viewModelType = assembly.GetType(viewModelTypeString);

            if (viewModelType is null)
            {
                throw new Exception($"Could not find viewmodel for page: {pageName}, expected viewmodel name: {viewModelTypeString}");
            }

            var pageInstance = Activator.CreateInstance(pageType) as ContentPage;

            var viewModelInstance = Activator.CreateInstance(viewModelType, new object[] { this });

            if (viewModelInstance is not null)
            {
                pageInstance.BindingContext = viewModelInstance;
            }

            await currentPage.Navigation.PushAsync(pageInstance);
        }

        public async Task NavigateAsync(string pageName, INavigationParameters navigationParameters)
        {
            if (navigationParameters is null)
                throw new ArgumentNullException(nameof(navigationParameters));

            var currentPage = App.Current.MainPage;

            if (currentPage is null)
            {
                throw new Exception("Could not find main page");
            }

            var assembly = Assembly.GetExecutingAssembly();

            if (assembly is null)
            {
                throw new Exception("Could not get current assembly");
            }

            var pageType = assembly.GetType(pageName);

            if (pageType is null)
            {
                throw new Exception($"Could not find type for name: {pageName}");
            }

            var viewModelTypeString = pageName.Replace("Page", "ViewModel");

            var viewModelType = assembly.GetType(viewModelTypeString);

            if (viewModelType is null)
            {
                throw new Exception($"Could not find viewmodel for page: {pageName}, expected viewmodel name: {viewModelTypeString}");
            }

            var interfaces = viewModelType.GetInterfaces();

            if (!interfaces.Contains(typeof(IInitialize)))
            {
                throw new Exception($"Cannot use {nameof(IInitialize)} because viewmodel does not implement it");
            }

            var pageInstance = Activator.CreateInstance(pageType) as ContentPage;

            var viewModelInstance = Activator.CreateInstance(viewModelType, new object[] { this });

            if (viewModelInstance is not null)
            {
                pageInstance.BindingContext = viewModelInstance;
            }

            var viewModelInitializer = viewModelInstance as IInitialize;

            if (viewModelInitializer is null)
            {
                throw new Exception($"Could not cast viewmodel as {nameof(IInitialize)}");
            }

            viewModelInitializer.Initialize(navigationParameters);

            await currentPage.Navigation.PushAsync(pageInstance);
        }
    }
}
