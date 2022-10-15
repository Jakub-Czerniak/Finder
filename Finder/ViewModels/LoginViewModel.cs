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
        void Login()
        {
            //Api call
        }

        [RelayCommand]
        async void GoToRegistration()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterNamePage)}");
        }


    }
}
