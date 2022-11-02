using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;

namespace Finder.ViewModels
{
    [QueryProperty ("User","User")]
    public partial class UserEditViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        [ObservableProperty]
        string interestString;
        [ObservableProperty]
        string intrestedInString;

        [RelayCommand]
        async void Logout()
        {
            await Shell.Current.GoToAsync("//Login");
        }

        [RelayCommand]
        async void ProfilePreview()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(UserDetailsViewModel)}", navigationParametr);
        }

        void makeInterestString()
        {
            interestString = "Zainteresowania, różne";
        }

        void makeIntrestedInString()
        {
            intrestedInString = "Kobiety";
        }

        public UserEditViewModel()
        {
            makeInterestString();
            makeIntrestedInString();    
        }
    }
}
