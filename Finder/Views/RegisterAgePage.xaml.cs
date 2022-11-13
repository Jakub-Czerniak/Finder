using Finder.ViewModels;

namespace Finder.Views;

public partial class RegisterAgePage : ContentPage
{
	public RegisterAgePage()
	{
		InitializeComponent();
		BindingContext = new RegisterAgeViewModel();
	}
}