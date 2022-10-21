using Finder.ViewModels;

namespace Finder.Views;

public partial class RegisterPasswordPage : ContentPage
{
	public RegisterPasswordPage()
	{
		InitializeComponent();
		BindingContext = new RegisterPasswordViewModel();
	}
}