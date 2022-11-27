using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Finder.Models;
using CommunityToolkit.Mvvm.Input;
using Finder.Views;
using DataAccess.Data;
using System.Net.Http.Headers;

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
        async void UserTapped(UserModel tappedUser)
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User},
                {"TappedUser", tappedUser}
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
                var interestsData = await UserData.GetUserInterests(pair.Id);
                ObservableCollection<InterestModel> interests = new ObservableCollection<InterestModel>();
                foreach (var interest in interestsData)
                    interests.Add(new InterestModel { Id = interest.Id, Name = interest.Name});
                MatchedUsers.Add(new UserModel
                {
                    Id = pair.Id,
                    Name = pair.Name,
                    AboutMe = pair.AboutMe,
                    Age = pair.Age,
                    Photo = pair.Photo,
                    Interests = interests
                });

            }
        }

        public MatchedUsersViewModel()
        {
            matchedUsers = new ObservableCollection<UserModel>();
        }
    }
}
