using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;

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
            //MainPage = new AppShell();
            //go to main page
        }

        [RelayCommand]
        async void AddPhoto()
        {
            FileResult photo = await MediaPicker.Default.PickPhotoAsync();

            if(photo != null)
            {
                Stream stream = await photo.OpenReadAsync();
                User.Photo = new Image { Source = ImageSource.FromStream(() => stream) };
            }

        }
        public RegisterPhotoViewModel()
        {
            
        }
    }
}

