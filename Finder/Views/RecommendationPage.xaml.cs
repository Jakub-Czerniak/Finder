using Finder.ViewModels;

namespace Finder.Views;

public partial class RecommendationPage : ContentPage
{
	public RecommendationPage()
	{
		InitializeComponent();
		BindingContext = new RecommendationViewModel();
	}
}