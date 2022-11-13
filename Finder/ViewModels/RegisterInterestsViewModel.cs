using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using DataAccess;
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

        [RelayCommand]
        async void FinishRegistration()
        {
            Task.Run(async() => await Data.InsertUser(user.Name, user.Email, user.Password, user.Gender, user.Photo, user.InterestedM.ToString(), user.InterestedF.ToString(), user.Birthday));
            Task<DataAccess.Models.UserModel> task = Task<UserModel>.Run(async() => await Data.Login(user.Email, user.Password));
            User.Id = task.Result.Id;
            User.Age = task.Result.Age;
            User.MaxAgePreference = task.Result.MaxAgePreference;
            User.MinAgePreference = task.Result.MinAgePreference;
            foreach (var interest in User.Interests)
                await Data.InsertUserInterest(user.Id ,interest.Id);
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync("//Home", navigationParametr);
        }

        void OnInterestTapped(InterestModel interest)
        {
            if (User.Interests.Count <= 5)
            {
                if(!User.Interests.Contains(interest))
                    User.Interests.Add(interest);
                else
                    User.Interests.Remove(interest);
            }
        }

        async Task GetInterestList()
        {
            var data = await Data.GetInterests();
            foreach (var item in data)
                interests.Add(new InterestModel
                {
                    Id = item.Id,
                    Name = item.Name
                });
        }

        public  RegisterInterestsViewModel()
        {
            User.Interests = new List<InterestModel>();
            Task.Run(async() => await GetInterestList());
            
        }
    }
}
