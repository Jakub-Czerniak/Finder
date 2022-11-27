using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;

namespace Finder.ViewModels
{
    [QueryProperty ("User", "User")]
    public partial class RegisterGenderViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        [RelayCommand]
        void MenTapped()
        {
            User.Gender = "Mężczyzna";
            GoToRegisterInterestedIn();
        }

        [RelayCommand]
        void WomenTapped()
        {
            User.Gender = "Kobieta";
            GoToRegisterInterestedIn();
        }

        async void GoToRegisterInterestedIn()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(RegisterInterestedInPage)}", navigationParametr);
        }

    }
}
