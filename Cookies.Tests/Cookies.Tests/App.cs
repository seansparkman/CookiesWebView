using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Cookies.Tests
{
    public class App
    {
        public static Page MainPage
        {
            get
            {
                var webView = new CookieWebView
                {
                    Source = new UrlWebViewSource
                    {
                        Url = "http://www.xamarin.com"
                    }
                };

                webView.Navigated += (sender, args) =>
                {
                    Debug.WriteLine("Finished navigation to: {0}, Cookies: {1}", args.Url, args.Cookies.Count);
                };
                webView.Navigating += (sender, args) =>
                {
                    Debug.WriteLine("Navigating to: {0}", args.Url);
                };

                return new ContentPage
                {
                    Content = webView
                };
            }
        }
    }
}
