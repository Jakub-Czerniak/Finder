using Android.Telecom;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;

namespace Finder.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        [RelayCommand]
        async void Login()
        {
            user = new UserModel();
            //User = //Api call
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync("//Home", navigationParametr);
        }

        [RelayCommand]
        async void GoToRegistration()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterNamePage)}");
        }


    }
}
