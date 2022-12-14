using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;
using DataAccess.Data;
using System.Collections.ObjectModel;

namespace Finder.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        [ObservableProperty]
        bool failedLogin;

        [RelayCommand]
        async void Login()
        {
            FailedLogin = false;
            var data = await LoginData.Login(user.Email, user.Password);
            if(data == null)
            {
                FailedLogin = true;
                return;
            }
            User.Name = data.Name;
            User.Gender = data.Gender;
            User.AboutMe = data.AboutMe;
            User.Id = data.Id;
            User.MaxAgePreference = data.MaxAgePreference;
            User.MinAgePreference = data.MinAgePreference;
            User.Photo = data.Photo;
            User.Email = data.Email;
            User.Age= data.Age;
            User.InterestedM = bool.Parse(data.InterestedM);
            User.InterestedF = bool.Parse(data.InterestedF);
            User.IsRegistered = true;

            var interests = await UserData.GetUserInterests(User.Id);
            foreach (var interest in interests)
                User.Interests.Add( new InterestModel
                { 
                    Name = interest.Name, 
                    Id = interest.Id, 
                    ButtonColor = Color.FromArgb("B73E3E")
                });

            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(RecommendationPage)}", navigationParametr);
        }

        [RelayCommand]
        async void GoToRegistration()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterNamePage)}");
        }

        public LoginViewModel()
        {
            User = new UserModel
            {
                Interests = new ObservableCollection<InterestModel>(),
                Email = "",
                Password = ""
        };
        }

    }
}
