using CommunityToolkit.Maui;
using Finder.Views;
using Finder.ViewModels;

namespace Finder;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

		builder.Services.AddTransient<RegisterNamePage>();
		builder.Services.AddTransient<RegisterNameViewModel>();

        return builder.Build();
	}
}
