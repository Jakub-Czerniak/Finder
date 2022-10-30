using Finder.Views;

namespace Finder;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(RecommendationPage), typeof(RecommendationPage));

        Routing.RegisterRoute(nameof(RegisterNamePage), typeof(RegisterNamePage));
        Routing.RegisterRoute(nameof(RegisterEmailPage), typeof(RegisterEmailPage));
        Routing.RegisterRoute(nameof(RegisterPasswordPage), typeof(RegisterPasswordPage));
        Routing.RegisterRoute(nameof(RegisterGenderPage), typeof(RegisterGenderPage));
        Routing.RegisterRoute(nameof(RegisterPhotoPage), typeof(RegisterPhotoPage));
        Routing.RegisterRoute(nameof(RegisterInterestedInPage), typeof(RegisterInterestedInPage));
    }
}
