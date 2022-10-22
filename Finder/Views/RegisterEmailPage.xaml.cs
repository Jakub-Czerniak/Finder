using Finder.ViewModels;

namespace Finder.Views;

public partial class RegisterEmailPage : ContentPage
{
	public RegisterEmailPage()
	{
		InitializeComponent();
		BindingContext = new RegisterEmailViewModel();
	}
}