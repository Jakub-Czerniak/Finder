using Finder.ViewModels;

namespace Finder.Views;

public partial class RegisterInterestedInPage : ContentPage
{
	public RegisterInterestedInPage()
	{
		InitializeComponent();
		BindingContext = new RegisterInterestedInViewModel();
	}
}