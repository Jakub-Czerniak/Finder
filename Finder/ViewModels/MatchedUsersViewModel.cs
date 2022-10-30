using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Finder.Models;
using CommunityToolkit.Mvvm.Input;
using Finder.Views;

namespace Finder.ViewModels
{
    [QueryProperty ("User","User")]
    public partial class MatchedUsersViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;
        [ObservableProperty]
        ObservableCollection<UserModel> matchedUsers;

        [RelayCommand]
        async void OnUserTapped(UserModel tappedUser)
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User },
                {"tappedUser", tappedUser }
            };
            await Shell.Current.GoToAsync($"{nameof(UserDetailsPage)}", navigationParametr);
        }

        [RelayCommand]
        void LoadMatchedUsers()
        {
            //MatchedUsers = //apicall;
        }

        public MatchedUsersViewModel()
        {
            matchedUsers = new ObservableCollection<UserModel>();
        }
    }
}
