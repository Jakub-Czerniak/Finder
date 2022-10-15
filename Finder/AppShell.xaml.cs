using Finder.Views;

namespace Finder;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(RegisterNamePage),typeof(RegisterNamePage));
	}
}
