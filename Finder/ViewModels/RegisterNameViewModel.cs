using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;


namespace Finder.ViewModels
{
    public partial class RegisterNameViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        [RelayCommand]
        async void GoToRegistrationEmail()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };

            await Shell.Current.GoToAsync($"{nameof(RegisterEmailPage)}",navigationParametr);
        }
    }
}
