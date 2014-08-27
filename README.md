CookiesWebView
==============

Xamarin.Forms Web View that supports cookies and loading pages event


For Windows Phone, you will need to add this field initializer to your MainPage.xaml.cs.

    public partial class MainPage : PhoneApplicationPage
    {
        CookieWebViewRenderer _renderer = new CookieWebViewRenderer();
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = Cookies.Tests.App.MainPage.ConvertPageToUIElement(this);
        }
    }
