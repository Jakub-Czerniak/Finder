using Finder.ViewModels;

namespace Finder.Views;

public partial class RegisterNamePage : ContentPage
{
	public RegisterNamePage()
	{
		InitializeComponent();
		BindingContext = new RegisterNameViewModel();
	}
}