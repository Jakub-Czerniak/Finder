using Finder.Views;

namespace Finder;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(RecommendationPage), typeof(RecommendationPage));
        Routing.RegisterRoute(nameof(UserEditPage), typeof(UserEditPage));
        Routing.RegisterRoute(nameof(MatchedUsersPage), typeof(MatchedUsersPage));
        Routing.RegisterRoute(nameof(UserDetailsPage), typeof(UserDetailsPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

        Routing.RegisterRoute(nameof(RegisterNamePage), typeof(RegisterNamePage));
        Routing.RegisterRoute(nameof(RegisterEmailPage), typeof(RegisterEmailPage));
        Routing.RegisterRoute(nameof(RegisterPasswordPage), typeof(RegisterPasswordPage));
        Routing.RegisterRoute(nameof(RegisterGenderPage), typeof(RegisterGenderPage));
        Routing.RegisterRoute(nameof(RegisterPhotoPage), typeof(RegisterPhotoPage));
        Routing.RegisterRoute(nameof(RegisterInterestedInPage), typeof(RegisterInterestedInPage));
        Routing.RegisterRoute(nameof(RegisterInterestsPage), typeof(RegisterInterestsPage));
        Routing.RegisterRoute(nameof(RegisterAgePage), typeof(RegisterAgePage));
    }
}
