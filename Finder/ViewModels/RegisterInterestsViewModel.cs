using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;

namespace Finder.ViewModels
{
    [QueryProperty ("User", "User")]
    public partial class RegisterInterestsViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        [RelayCommand]
        async void FinishRegistration()
        {
            //api call
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync("//Home", navigationParametr);
        }

    }
}
