using Finder.ViewModels;

namespace Finder.Views;

public partial class RegisterInterestsPage : ContentPage
{
	public RegisterInterestsPage()
	{
		InitializeComponent();
		BindingContext = new RegisterInterestsViewModel();
	}
}