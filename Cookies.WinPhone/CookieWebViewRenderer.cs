using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Cookies;
using Cookies.WinPhone;
using Microsoft.Phone.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(CookieWebView), typeof(CookieWebViewRenderer))]
namespace Cookies.WinPhone
{
    public class CookieWebViewRenderer
        : Xamarin.Forms.Platform.WinPhone.WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Navigating += ControlOnNavigating;
                Control.Navigated += ControlOnNavigated;
            }
        }

        protected void ControlOnNavigated(object sender, System.Windows.Navigation.NavigationEventArgs navigationEventArgs)
        {
            CookieWebView.OnNavigated(new CookieNavigatedEventArgs()
            {
                Cookies = Control.GetCookies(),
                Url = navigationEventArgs.Uri.ToString()
            });
        }

        protected void ControlOnNavigating(object sender, NavigatingEventArgs navigatingEventArgs)
        {
            CookieWebView.OnNavigating(new CookieNavigationEventArgs()
            {
                Url = navigatingEventArgs.Uri.ToString()
            });
        }

        public CookieWebView CookieWebView
        {
            get { return Element as CookieWebView; }
        }
    }
}
