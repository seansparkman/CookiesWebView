using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Cookies;
using Cookies.iOS.Views;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(CookieWebView), typeof(CookieWebViewRenderer))]
namespace Cookies.iOS.Views
{
    public class CookieWebViewRenderer
        : Xamarin.Forms.Platform.iOS.WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Delegate = new WebViewDelegate(CookieWebView);
            }
        }

        public CookieWebView CookieWebView
        {
            get { return Element as CookieWebView; }
        }
    }

    internal class WebViewDelegate : UIWebViewDelegate
    {
        private CookieWebView _cookieWebView;

        public WebViewDelegate(CookieWebView cookieWebView)
        {
            _cookieWebView = cookieWebView;
        }

        public override bool ShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
        {
            webView.UserInteractionEnabled = false;
            _cookieWebView.OnNavigating(new CookieNavigationEventArgs
            {
                Url = request.Url.AbsoluteString
            });
            return true;
        }

        public override void LoadStarted(UIWebView webView)
        {
            // TODO: Add code here to possible redirect
        }

        public override void LoadFailed(UIWebView webView, NSError error)
        {
            // TODO: Display Error Here
            Debug.WriteLine("ERROR: {0}", error.ToString());
        }

        public override void LoadingFinished(UIWebView webView)
        {
            NSHttpCookieStorage storage = NSHttpCookieStorage.SharedStorage;
            webView.UserInteractionEnabled = true;

            var cookieCollection = new CookieCollection();
            foreach (var cookie in storage.Cookies)
            {
                cookieCollection.Add(new Cookie
                {
                    Comment = cookie.Comment,
                    
                    Domain = cookie.Domain,
                    
                    HttpOnly = cookie.IsHttpOnly,
                    Name = cookie.Name,
                    Path = cookie.Path,
                    Secure = cookie.IsSecure,
                    Value = cookie.Value,
                    // TODO: Discard = cookie.IsSessionOnly, // ios version is a dictionary, might not be added
                    Version = Convert.ToInt32(cookie.Version)
                });
                // TODO:  Expires = cookie.ExpiresDate,
                // TODO: CommentUri = new Uri(cookie.CommentUrl.AbsoluteString),
                // TODO: something with the port
            }

            _cookieWebView.OnNavigated(new CookieNavigatedEventArgs
            {
                Cookies = cookieCollection,
                Url = webView.Request.Url.AbsoluteString
            });
        }
    }
}