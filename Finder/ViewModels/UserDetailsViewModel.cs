using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finder.Models;

namespace Finder.ViewModels
{
    [QueryProperty ("User","User")]
    [QueryProperty ("TappedUser","TappedUser")]
    public partial class UserDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;
        [ObservableProperty]
        UserModel tappedUser;
        [ObservableProperty]
        string interestString;

        [RelayCommand]
        void MakeInterestString()
        {
            InterestString = "Brak zainteresowań";
            foreach (var interest in TappedUser.Interests)
            {
                if (interest != TappedUser.Interests[0])
                    InterestString += ", ";
                else
                    InterestString = "";
                InterestString += $"{interest.Name}";
            }
        }

    }
}
