using Finder.ViewModels;

namespace Finder.Views;

public partial class MatchedUsersPage : ContentPage
{
	public MatchedUsersPage()
	{
		InitializeComponent();
		BindingContext = new MatchedUsersViewModel();
	}
}