using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;
using DataAccess;

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
            /*var data = await Data.Login(user.Email, user.Password);
            //User.Interests= api call;

            User.AboutMe = data.AboutMe;
            User.Id = data.Id;
            User.MaxAgePreference = data.MaxAgePreference;*/

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
