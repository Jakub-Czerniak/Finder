using Finder.ViewModels;

namespace Finder.Views;

public partial class UserEditPage : ContentPage
{
	public UserEditPage()
	{
		InitializeComponent();
		BindingContext = new UserEditViewModel();
	}
}