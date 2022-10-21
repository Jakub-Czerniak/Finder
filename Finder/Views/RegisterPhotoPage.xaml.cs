using Finder.ViewModels;

namespace Finder.Views;

public partial class RegisterPhotoPage : ContentPage
{
	public RegisterPhotoPage()
	{
		InitializeComponent();
		BindingContext = new RegisterPhotoViewModel();
	}
}