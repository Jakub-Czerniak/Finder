using Finder.ViewModels;

namespace Finder.Views;

public partial class RecommendationSettingsPage : ContentPage
{
	public RecommendationSettingsPage()
	{
		InitializeComponent();
		BindingContext = new RecommendationSettingsViewModel();
	}
}