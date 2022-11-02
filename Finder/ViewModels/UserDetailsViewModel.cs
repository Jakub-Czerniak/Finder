﻿using CommunityToolkit.Mvvm.ComponentModel;
using Finder.Models;

namespace Finder.ViewModels
{
    [QueryProperty ("User","User")]
    public partial class UserDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;


    }
}
