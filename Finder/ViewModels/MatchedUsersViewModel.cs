using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Finder.Models;
using CommunityToolkit.Mvvm.Input;
using Finder.Views;
using DataAccess.Data;

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
        async void GoToUserEdit()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(UserEditPage)}", navigationParametr);
        }

        [RelayCommand]
        async void GoToRecommendation()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(RecommendationPage)}", navigationParametr);
        }


        [RelayCommand]
        async void OnUserTapped(UserModel tappedUser)
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User },
                {"TappedUser", tappedUser }
            };
            await Shell.Current.GoToAsync($"{nameof(UserDetailsPage)}", navigationParametr);
        }

        [RelayCommand]
        async void LoadMatchedUsers()
        {
            var data = await PairData.GetPairs(User.Id);
            MatchedUsers.Clear();
            foreach (var pair in data)
            {
                MatchedUsers.Add(new UserModel
                {
                    Id = pair.Id,
                    Name = pair.Name,
                    AboutMe = pair.AboutMe,
                    Age = pair.Age,
                    Photo = pair.Photo
                });
            }
        }

        public MatchedUsersViewModel()
        {
            matchedUsers = new ObservableCollection<UserModel>();
        }
    }
}
