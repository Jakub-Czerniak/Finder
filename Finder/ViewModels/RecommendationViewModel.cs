using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;

namespace Finder.ViewModels
{
    [QueryProperty ("User", "User")]
    public partial class RecommendationViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;
        [ObservableProperty]
        UserModel recommendedUser;

        [ObservableProperty]
        string aboutMeShort;

        [RelayCommand]
        async void GoToMatchedUsers()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(MatchedUsersPage)}", navigationParametr);
        }

        [RelayCommand]
        async void GoToUserEdit()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(UserEditPage)}", navigationParametr);
        }
        void CreateAboutMeShort()
        {
            //throw new NotImplementedException();
        }

        public RecommendationViewModel()
        {
            CreateAboutMeShort();
        }

    }
}
