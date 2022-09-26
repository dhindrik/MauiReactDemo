using System;
using Android.Content;
using Android.Webkit;
using Java.Interop;

namespace Reacting;

public class JavaScriptHandler : Java.Lang.Object
{

    [JavascriptInterface]
    [Export]
    public void Hello()
    {

    }

    [JavascriptInterface]
    [Export()]
    public string GetLocation()
    {
        Location location = null;

        var resetEvent = new ManualResetEvent(false);

        MainThread.BeginInvokeOnMainThread(async() => {
            location =  await Geolocation.GetLocationAsync();
            resetEvent.Set();
        });

        resetEvent.WaitOne();

        var locationString = $"{location.Latitude}:{location.Longitude}";

        return locationString;
    }
}

