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
        private static Label _label;
        public static Page MainPage
        {
            get
            {
                _label = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    Text = "Loading..."
                };

                var webView = new CookieWebView
                {
                    Source = new UrlWebViewSource
                    {
                        Url = "http://dfwmobile.net"
                    },
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                webView.Navigated += (sender, args) =>
                {
                    Debug.WriteLine("Finished navigation to: {0}, Cookies: {1}", args.Url, args.Cookies.Count);
                    _label.Text = args.Url;
                };
                webView.Navigating += (sender, args) =>
                {
                    Debug.WriteLine("Navigating to: {0}", args.Url);
                    _label.Text = args.Url;
                };

                return new ContentPage
                {
                    Content = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Children = { _label, webView }
                    }
                };
            }
        }
    }
}
