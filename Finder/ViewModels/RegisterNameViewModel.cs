using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;
using System.Collections.ObjectModel;

namespace Finder.ViewModels
{
    public partial class RegisterNameViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;
        [ObservableProperty]
        bool isValidEntry;
        [ObservableProperty]
        bool isVisibleEntryError;

        [RelayCommand]
        async void GoToRegisterAge()
        {
             if (IsValidEntry)
            {
                var navigationParametr = new Dictionary<string, object>
                {
                {"User", User }
                };
                await Shell.Current.GoToAsync($"{nameof(RegisterAgePage)}", navigationParametr);
            }
            else
            {
                IsVisibleEntryError = true;
            }
        }

        public RegisterNameViewModel()
        {
            user = new UserModel();
            User.Name = "";
            User.Email = "";
            User.Password = "";
            User.AboutMe = "";
            User.Interests = new ObservableCollection<InterestModel>();
        }
    }
}
