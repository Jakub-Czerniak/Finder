using CommunityToolkit.Mvvm.ComponentModel;
using Finder.Models;

namespace Finder.ViewModels
{
    [QueryProperty ("User","User")]
    public partial class UserEditViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;


    }
}
