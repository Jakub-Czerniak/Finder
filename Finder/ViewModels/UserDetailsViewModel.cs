using CommunityToolkit.Mvvm.ComponentModel;
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




    }
}
