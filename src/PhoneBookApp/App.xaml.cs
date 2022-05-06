using Prism;
using Prism.Navigation;

namespace PhoneBookApp
{
    public partial class App : PrismApplication
	{
		public App()
		{
            InitializeComponent();
		}

        protected override async Task OnWindowCreated(IActivationState activationState)
        {
            var nav = await NavigationService.NavigateAsync("NavigationPage/AddressBookPage");

            if (!nav.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
    }
}
