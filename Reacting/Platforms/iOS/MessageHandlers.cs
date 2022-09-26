using System;
using Foundation;
using WebKit;

namespace Reacting;

public class MessageHandler : NSObject, WebKit.IWKScriptMessageHandler
{
    public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
    {

    }
}

public class MessageHandlerWithReply : NSObject, WebKit.IWKScriptMessageHandlerWithReply
{
    public async void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message, Action<NSObject, NSString> replyHandler)
    {
        var location = await Geolocation.GetLocationAsync();

        var locationString = $"{location.Latitude}:{location.Longitude}";

        replyHandler(NSObject.FromObject(locationString), null);
    }
}

