using DataAccess.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;

namespace Finder.ViewModels
{
    [QueryProperty ("User","User")]
    public partial class UserEditViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;
        [ObservableProperty]
        string interestString;
        [ObservableProperty]
        string intrestedInString;

        bool maxEntryIsValid()
        {
            if (User.MaxAgePreference > User.MinAgePreference & User.MaxAgePreference <= 120)
                return true;
            return false;
        }
        bool minEntryIsValid()
        {
            if (User.MinAgePreference < User.MaxAgePreference & User.MinAgePreference >= 14)
                return true;
            return false;
        }
        [ObservableProperty]
        bool isVisibleEntryError;

        bool doNotUpdate;

        [RelayCommand]
        async void Logout()
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }

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
        async void GoToRecommendation()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(RecommendationPage)}", navigationParametr);
        }

        [RelayCommand]
        async void GoToRegisterPhoto()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(RegisterPhotoPage)}", navigationParametr);
        }

        [RelayCommand]
        async void GoToRegisterInterestedIn()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(RegisterInterestedInPage)}", navigationParametr);
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
        async void ProfilePreview()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User },
                {"TappedUser", User }
            };
            await Shell.Current.GoToAsync($"{nameof(UserDetailsViewModel)}", navigationParametr);
        }


        [RelayCommand]
        async void DeleteUser()
        {
            doNotUpdate = true;
            await UserData.DeleteUser(User.Id);
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }

        [RelayCommand]
        async Task UpdateUser()
        {
            if (!doNotUpdate & maxEntryIsValid() & minEntryIsValid())
            {
                await UserData.UpdateUser(User.Id, User.Photo, User.InterestedF.ToString(), User.InterestedM.ToString(), 
                    User.AboutMe, User.MinAgePreference, User.MaxAgePreference);
            }
        }

        [RelayCommand]
        void AgePreferenceValidityCheck()
        {
            if (minEntryIsValid() & maxEntryIsValid())
                IsVisibleEntryError = false;
            else
                IsVisibleEntryError = true;
        }

        void makeInterestString()
        {
            InterestString = "Wybierz zainteresowania";
            foreach (var interest in User.Interests)
            {
                if (interest != User.Interests[0])
                    InterestString += ", ";
                else
                    InterestString = "";
                InterestString += $"{interest.Name}";
            }
        }

        void makeIntrestedInString()
        {
            intrestedInString = "";
            if (user.InterestedF & user.InterestedM)
                IntrestedInString = "Kobiety, Mężczyźni";
            else if (user.InterestedM)
                IntrestedInString = "Mężczyźni";
            else if (user.InterestedF)
                IntrestedInString = "Kobiety";
        }

        [RelayCommand]
        void Appearing()
        {
            makeInterestString();
            makeIntrestedInString();
        }
    }
}
