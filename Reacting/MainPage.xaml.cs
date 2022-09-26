namespace Reacting;

public partial class MainPage
{
	public MainPage()
	{
		InitializeComponent();

		Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebViewHandler.BlazorWebViewMapper.AppendToMapping("Custom", (handler, view) =>
		{
#if IOS || MACCATALYST
            handler.PlatformView.Configuration.UserContentController.AddScriptMessageHandler(new MessageHandler(), "Hello");
            handler.PlatformView.Configuration.UserContentController.AddScriptMessageHandler(new MessageHandlerWithReply(),WKContentWorld.Page, "GetLocation");
#elif ANDROID
			handler.PlatformView.Settings.JavaScriptEnabled = true;
			handler.PlatformView.AddJavascriptInterface(new JavaScriptHandler(), "Native");
#endif

        });
	}
}
