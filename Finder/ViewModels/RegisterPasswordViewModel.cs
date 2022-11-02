using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;

namespace Finder.ViewModels
{
    [QueryProperty("User", "User")]
    public partial class RegisterPasswordViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;
        [ObservableProperty]
        bool isValidEntry;
        [ObservableProperty]
        bool isVisibleEntryError;

        [RelayCommand]
        async void GoToRegisterGender()
        {
            if (IsValidEntry)
            {
                var navigationParametr = new Dictionary<string, object>
                {
                {"User", User }
                };
                await Shell.Current.GoToAsync($"{nameof(RegisterGenderPage)}", navigationParametr);
            }
            else 
            {
                IsVisibleEntryError = true;
            }
        }
    }
}
