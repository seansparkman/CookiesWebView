using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cookies.iOS.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Cookies.Tests.iOS
{
    public class IncludeLinker
    {
        public void Include(CookieWebViewRenderer renderer)
        {
            renderer.Add(null);
        }
    }
}