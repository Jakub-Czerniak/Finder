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
        [ObservableProperty]
        bool isVisibleEntryError;


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
                User.InterestedM=menTapped = false;
            }
            else
            {
                MenButtonColor = tappedColor;
                User.InterestedM=menTapped = true;
            }
        }

        [RelayCommand]
        void WomenTapped()
        {
            if (womenTapped)
            {
                WomenButtonColor = untappedColor;
                User.InterestedF = womenTapped = false;
            }
            else
            {
                WomenButtonColor = tappedColor;
                User.InterestedF = womenTapped = true;
            }
        }

        [RelayCommand]
        async void GoToRegisterPhoto()
        {
            if (!menTapped & !womenTapped)
            {
                IsVisibleEntryError = true;
            }
            else
            {
                var navigationParametr = new Dictionary<string, object>
                {
                {"User", User }
                };
                await Shell.Current.GoToAsync($"{nameof(RegisterPhotoPage)}", navigationParametr);
            }
        }

        public RegisterInterestedInViewModel()
        {
            womenButtonColor = menButtonColor = untappedColor;
        }
    }
}
