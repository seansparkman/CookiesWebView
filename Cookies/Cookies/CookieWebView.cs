using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cookies
{
    public delegate void WebViewNavigatedHandler(object sender, CookieNavigationEventArgs args);
    public delegate void WebViewNavigatingHandler(object sender, CookieNavigationEventArgs args);

    public class CookieWebView
        : WebView
    {
        public CookieCollection Cookies { get; set; }

        public event WebViewNavigatedHandler Navigated;
        public event WebViewNavigatingHandler Navigating;

        public virtual void OnNavigated(CookieNavigationEventArgs args)
        {
            var eventHandler = Navigated;

            if (eventHandler != null)
            {
                eventHandler(this, args);
            }
        }

        public virtual void OnNavigating(CookieNavigationEventArgs args)
        {
            var eventHandler = Navigating;

            if (eventHandler != null)
            {
                eventHandler(this, args);
            }
        }
    }

    public class CookieNavigationEventArgs
        : EventArgs
    {
        public string Url { get; set; }
    }

    public class CookieNavigatedEventArgs
        : CookieNavigationEventArgs
    {
        public CookieCollection Cookies { get; set; }
        public CookieNavigationMode NavigationMode { get; set; }
    }

    public enum CookieNavigationMode
    {
        Back,
        Forward,
        New,
        Refresh,
        Reset
    }
}
