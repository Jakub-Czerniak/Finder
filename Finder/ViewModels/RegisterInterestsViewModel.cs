using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using DataAccess.Data;
using System.Collections.ObjectModel;

namespace Finder.ViewModels
{
    [QueryProperty ("User", "User")]
    public partial class RegisterInterestsViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;
        [ObservableProperty]
        ObservableCollection<InterestModel> interests = new ObservableCollection<InterestModel>();

        Color tappedColor = Color.FromArgb("DD5353"); 
        Color untappedColor = Color.FromArgb("B73E3E");

        [RelayCommand]
        async void FinishUpdateInterests()
        {
            Task.Run(async() => await UserData.DeleteUserInterests(user.Id));
            foreach (var interest in User.Interests)
                await UserData.InsertUserInterest(user.Id, interest.Id);
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync("//Home", navigationParametr);
        }

        [RelayCommand]
        async void FinishRegistration()
        {
            Task.Run(async() => await UserData.InsertUser(user.Name, user.Email, user.Password, user.Gender, user.Photo, user.InterestedM.ToString(), user.InterestedF.ToString(), user.Birthday));
            DataAccess.Models.UserModel userModel = await LoginData.Login(user.Email, user.Password);
            User.Id = userModel.Id;
            User.Age = userModel.Age;
            User.MaxAgePreference = userModel.MaxAgePreference;
            User.MinAgePreference = userModel.MinAgePreference;
            User.IsRegistered = true;
            foreach (var interest in User.Interests)
                await UserData.InsertUserInterest(user.Id ,interest.Id);
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync("//Home", navigationParametr);
        }

        [RelayCommand]
        void InterestTapped(InterestModel interest)
        {
            if (!User.Interests.Contains(interest))
            {
                if (User.Interests.Count < 5)
                {
                    interest.ButtonColor = tappedColor;
                    User.Interests.Add(interest);
                }
            }
            else
            {
                User.Interests.Remove(interest);
                interest.ButtonColor = untappedColor;
            }
            Interests.Move(0, 0);
        }

        async Task GetInterestList()
        {
            var data = await InterestsData.GetInterests();
            foreach (var item in data)
                interests.Add(new InterestModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    ButtonColor = untappedColor
                });
        }

        public RegisterInterestsViewModel()
        {
            Task.Run(async() => await GetInterestList());
        }
    }
}
