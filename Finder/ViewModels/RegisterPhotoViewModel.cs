using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;

namespace Finder.ViewModels
{
    [QueryProperty("User", "User")]
    public partial class RegisterPhotoViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        [RelayCommand]
        async void FinishRegistration()
        {
            //api call
            //go to main page
        }
    }
}
