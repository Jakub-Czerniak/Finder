using Finder.ViewModels;

namespace Finder.Views;

public partial class UserDetailsPage : ContentPage
{
	public UserDetailsPage()
	{
		InitializeComponent();
		BindingContext = new UserDetailsViewModel();
	}
}