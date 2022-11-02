using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;

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

        [RelayCommand]
        async void GoToRegisterPassword()
        {
            if (IsValidEntry)
            {
                var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
                await Shell.Current.GoToAsync($"{nameof(RegisterPasswordPage)}", navigationParametr);
            }
            else
            {
                IsVisibleEntryError = true;
            }
        }

    }
}
