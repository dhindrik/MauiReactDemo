global using Microsoft.AspNetCore.Components.WebView.Maui;
global using Reacting.Data;
global using Reacting;

#if IOS || MACCATALYST
global using Foundation;
global using ObjCRuntime;
global using WebKit;
#endif

namespace Reacting;

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
			});

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		
		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}

