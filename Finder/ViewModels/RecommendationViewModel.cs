using CommunityToolkit.Mvvm.ComponentModel;
using Finder.Models;

namespace Finder.ViewModels
{
    [QueryProperty ("User", "User")]
    public partial class RecommendationViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel user;
        [ObservableProperty]
        UserModel recommendedUser;

        [ObservableProperty]
        string aboutMeShort;

        void CreateAboutMeShort()
        {
            //throw new NotImplementedException();
        }

        public RecommendationViewModel()
        {
            CreateAboutMeShort();
        }

    }
}
