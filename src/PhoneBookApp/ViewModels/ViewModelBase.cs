using Ardalis.GuardClauses;
using Prism.Mvvm;
using Prism.Navigation;

namespace PhoneBookApp.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize
    {
        protected readonly INavigationService navigationService;

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ViewModelBase(INavigationService navigationService)
        {
            this.navigationService = Guard.Against.Null(navigationService, nameof(navigationService));
        }

        public virtual void Initialize(INavigationParameters parameters) { }
    }
}
