using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics;
using Finder.Models;
using Finder.Views;

namespace Finder.ViewModels
{
    [QueryProperty("User", "User")]
    public partial class RegisterInterestedInViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        [ObservableProperty]
        Color womenButtonColor;
        [ObservableProperty]
        public Color menButtonColor;

        Color tappedColor = Color.FromArgb("B73E3E");
        Color untappedColor = Color.FromArgb("DD5353");
        bool womenTapped;
        bool menTapped;

        [RelayCommand]
        void MenTapped()
        {
            if (menTapped)
            {
                MenButtonColor = untappedColor;
                menTapped = false;
            }
            else
            {
                MenButtonColor = tappedColor;
                menTapped=true;
            }
            User.InterestedM = !User.InterestedM;
        }

        [RelayCommand]
        void WomenTapped()
        {
            if (womenTapped)
            {
                WomenButtonColor = untappedColor;
                womenTapped = false;
            }
            else
            {
                WomenButtonColor = tappedColor;
                womenTapped = true;
            }
            User.InterestedF = !User.InterestedF;
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

        public RegisterInterestedInViewModel()
        {
            womenButtonColor = menButtonColor = untappedColor;
        }
    }
}
