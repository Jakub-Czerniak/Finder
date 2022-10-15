using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;

namespace Finder.ViewModels
{
    [QueryProperty ("User","User")]
    public partial class RegisterEmailViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        /*[RelayCommand]
        async void GoToPasswordregistration()
        {
            await Shell.Current.GoToAsync();
        }*/

    }
}
