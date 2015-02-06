using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace Cookies.Tests
{
    public class App : Application
    {
        public App()
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

            var refreshButton = new Button
            {
                Text = "Refresh"
            };
            refreshButton.Clicked += (sender, args) =>
            {
                webView.Source = new UrlWebViewSource
                {
                    Url = "http://dfwmobile.net"
                };
            };

            var cookieCountText = new Label
            {
                Text = "0"
            };

            var toolbarLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { refreshButton, cookieCountText }
            };

                

            webView.Navigated += (sender, args) =>
            {
                Debug.WriteLine("Finished navigation to: {0}, Cookies: {1}", args.Url, args.Cookies.Count);
                cookieCountText.Text = args.Cookies.Count.ToString();
                _label.Text = args.Url;
            };
            webView.Navigating += (sender, args) =>
            {
                Debug.WriteLine("Navigating to: {0}", args.Url);
                _label.Text = args.Url;
            };

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Children = { _label, toolbarLayout, webView }
                }
            };
            
        }
        private static Label _label;

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
