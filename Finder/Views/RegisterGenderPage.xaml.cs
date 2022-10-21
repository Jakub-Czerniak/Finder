using Finder.ViewModels;

namespace Finder.Views;

public partial class RegisterGenderPage : ContentPage
{
	public RegisterGenderPage()
	{
		InitializeComponent();
		BindingContext = new RegisterGenderViewModel();
	}
}