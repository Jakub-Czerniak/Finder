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
        async void GoToRegisterInterests()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(RegisterInterestsPage)}", navigationParametr);
            
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

