using System.Threading.Tasks;

namespace PhoneBookApp.Abstractions
{
    public interface INavigationService
    {
        Task NavigateAsync(string pageName);

        Task NavigateAsync(string pageName, INavigationParameters navigationParameters);

        Task GoBackAsync();
    }
}
