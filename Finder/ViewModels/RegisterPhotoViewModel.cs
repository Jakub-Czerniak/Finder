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
        byte[] photo;
        public byte[] Photo
        {
            get { return photo; }
            set 
            {
                photo = value;
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        async void FinishUpdatePhoto()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(UserEditPage)}", navigationParametr);
        }

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
            FileResult photo = await MediaPicker.PickPhotoAsync();
            
            if(photo != null)
            {
                Stream stream = await photo.OpenReadAsync();
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                User.Photo = memoryStream.ToArray();
                Photo = memoryStream.ToArray();
            }

        }
        public RegisterPhotoViewModel()
        {

        }
    }
}

