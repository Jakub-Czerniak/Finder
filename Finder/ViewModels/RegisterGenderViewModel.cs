﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;
using Finder.Views;

namespace Finder.ViewModels
{
    [QueryProperty ("User", "User")]
    public partial class RegisterGenderViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;

        [RelayCommand]
        async void GoToRegisterPhotot()
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"User", User }
            };
            await Shell.Current.GoToAsync($"{nameof(RegisterPhotoPage)}", navigationParametr);
        }

    }
}
