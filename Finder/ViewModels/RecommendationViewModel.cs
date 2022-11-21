using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;
using DataAccess.Data;
using System.Collections.ObjectModel;
using Java.Nio.Channels;

namespace Finder.ViewModels
{
    [QueryProperty ("User", "User")]
    public partial class RecommendationViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;
        [ObservableProperty]
        UserModel recommendedUser;

        int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }
        string name;
        public string Name { get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
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
        async Task GoToUserDetails()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User },
                {"TappedUser", recommendedUser }
            };
            await Shell.Current.GoToAsync($"{nameof(UserDetailsPage)}", navigationParametr);
        }

        [RelayCommand]
        async Task GoToMatchedUsers()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(MatchedUsersPage)}", navigationParametr);
        }

        [RelayCommand]
        async Task GoToUserEdit()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(UserEditPage)}", navigationParametr);
        }

        void loadRecommendation()
        {
            RecommendedUser = new UserModel();
            RecommendedUser.Interests = new ObservableCollection<InterestModel>();
            var recommendation = Task.Run(async()=> await MatchEngineData.GetBestMatch(User.Id)).Result;
            if (recommendation.MatchId == 0 | recommendation == null)
            {
                RecommendedUser.Id = 0;
                RecommendedUser.AboutMe = "";
                Age = RecommendedUser.Age = 0;
                Name = RecommendedUser.Name = "Brak użytkowników :";
                Photo = RecommendedUser.Photo = null;
                RecommendedUser.Interests.Clear();
                return;
            }
            var recUser = Task.Run(async () => await UserData.GetUser(recommendation.MatchId)).Result;
            var interestList = Task.Run(async () => await UserData.GetUserInterests(recommendation.MatchId)).Result;

            RecommendedUser.Id = recommendation.MatchId;
            RecommendedUser.AboutMe = recUser.AboutMe;
            Age = RecommendedUser.Age = recUser.Age;
            Name = RecommendedUser.Name = recUser.Name;
            Photo = RecommendedUser.Photo = recUser.Photo;

            foreach (var interest in interestList)
                RecommendedUser.Interests.Add(new InterestModel { Id = interest.Id, Name = interest.Name});
        }

        [RelayCommand]
        async Task SendPass()
        {
            await PairData.InsertDecision(User.Id, RecommendedUser.Id, "pass");
            loadRecommendation();
        }

        [RelayCommand]
        async Task SendLike()
        {
            await PairData.InsertDecision(User.Id, RecommendedUser.Id, "like");
            loadRecommendation();
        }

        [RelayCommand]
        void Appearing()
        {
            loadRecommendation();
        }

    }
}
