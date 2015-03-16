using System;
using Xamarin.Forms;
using Facebook;
namespace OAuthTwoDemo.XForms
{
	public class App
	{
		
		static volatile App _Instance;
		static object _SyncRoot = new Object();
		public static App Instance
		{
		get 
		{
		if (_Instance == null) 
			{
		lock (_SyncRoot) 
		{
			if (_Instance == null) {
		_Instance = new App ();
		_Instance.OAuthSettings = 
		new OAuthSettings (
        clientId: "360818430783991",
        scope: "basic",
		authorizeUrl: "http://www.facebook.com",  	
		redirectUrl: "http://www.facebook.com/login_success.html");   

							      
									
					}
				}
			}

				return _Instance;
			}
		}

		public OAuthSettings OAuthSettings { get; private set; }

		NavigationPage _NavPage;

		public Page GetMainPage ()
		{
			var profilePage = new ProfilePage();

			_NavPage = new NavigationPage(profilePage);

			return _NavPage;
		}

		public bool IsAuthenticated {
			get { return !string.IsNullOrWhiteSpace(_Token); }
		}

		string _Token;
		public string Token {
			get { return _Token; }
		}

		public void SaveToken(string token)
		{
			_Token = token;

			
			MessagingCenter.Send<App> (this, "Authenticated");
		}

		public Action SuccessfulLoginAction
		{
			get {
				return new Action (() => _NavPage.Navigation.PopModalAsync ());
			}
		}
	}
}

