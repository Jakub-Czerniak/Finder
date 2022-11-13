using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;

namespace Finder.ViewModels
{
    [QueryProperty ("User", "User")]
    public partial class RegisterAgeViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;
        [ObservableProperty]
        int currentYear;

        int day;
        int month;
        int year;

        public int Day
        {
            get => day;
            set 
            {
                if(value <= 31 & value > 0 )
                    day = value;
                OnPropertyChanged();
            }
        }
        public int Month
        {
            get => month;
            set
            {
                if (value <= 12 & value > 0)
                    month = value;
                OnPropertyChanged();
                
            }
        }
        public int Year
        {
            get => year;
            set
            {
                if (value <= DateTime.Now.Year & value > 0)
                    year = value;
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        async Task GoToRegisterEmail()
        {
            if (year >= 1900)
            {
                User.Birthday = new DateTime(year, month, day);
                var navigationParametr = new Dictionary<string, object>
                {
                {"User", User }
                };
                await Shell.Current.GoToAsync($"{nameof(RegisterEmailPage)}", navigationParametr);
            }
        }

        public RegisterAgeViewModel()
        {
            CurrentYear = DateTime.Now.Year;
            Year = 1990;
            Month = 1;
            Day = 1;
        }
    }
}
