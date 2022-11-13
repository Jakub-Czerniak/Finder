using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;
using DataAccess;

namespace Finder.ViewModels
{
    [QueryProperty ("User","User")]
    public partial class RegisterEmailViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;
        [ObservableProperty]
        bool isValidEntry;
        [ObservableProperty]
        bool isVisibleEntryError;
        [ObservableProperty]
        bool isVisibleUniqueError;

        [RelayCommand]
        async void GoToRegisterPassword()
        {
            var IsUnique = await Data.EmailIsUnique(User.Email);

            if (IsValidEntry &  IsUnique)
            {
                var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
                await Shell.Current.GoToAsync($"{nameof(RegisterPasswordPage)}", navigationParametr);
            }
            else if (IsValidEntry)
            {
                IsVisibleEntryError = false;
                IsVisibleUniqueError = true;
            }
            else
            {
                IsVisibleUniqueError = false;
                IsVisibleEntryError = true;
            }
        }

    }
}
