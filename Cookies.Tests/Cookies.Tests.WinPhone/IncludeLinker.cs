using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cookies.WinPhone;

namespace Cookies.Tests.iOS
{
    public class IncludeLinker
    {
        public void Include(CookieWebViewRenderer renderer)
        {
            var height = renderer.ActualHeight;
        }
    }
}