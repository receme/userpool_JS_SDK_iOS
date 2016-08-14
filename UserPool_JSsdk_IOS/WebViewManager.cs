using System;
using Foundation;
using UIKit;
using Core;
using cdeutsch;

namespace UserPool_JSsdk_IOS
{
	public class WebViewManager : IWebviewmanager
	{
		UIWebView webView;
		UserpoolGateway userpoolGateway;
		static WebViewManager instance;

		public Action<FireEventData> OnSuccess;
		public Action<FireEventData> OnFailure;

		WebViewManager ()
		{
			webView = new UIWebView ();

			string path = NSBundle.MainBundle.PathForResource ("www/main", "html");
			string address = string.Format ("file:{0}", path).Replace (" ", "%20");
			webView.LoadRequest (new NSUrlRequest (new NSUrl (address)));

			userpoolGateway = new UserpoolGateway (webView);
		}

		public static WebViewManager GetInstance ()
		{
			if (instance == null) {
				instance = new WebViewManager ();
			}

			return instance;
		}

		public void Signup (string email, string password, string onSuccess, string onFailure)
		{
			userpoolGateway.OnSuccess += OnSuccess;
			userpoolGateway.OnFailure += OnFailure;
			userpoolGateway.Signup (email, password, onSuccess, onFailure);
		}

		public void ConfirmRegistration (string email, string code, string onSuccess, string onFailure)
		{
			userpoolGateway.OnSuccess += OnSuccess;
			userpoolGateway.OnFailure += OnFailure;
			userpoolGateway.ConfirmRegistration (email, code, onSuccess, onFailure);
		}

		public void AuthenticateUser (string email, string password, string onSuccess, string onFailure)
		{
			userpoolGateway.OnSuccess += OnSuccess;
			userpoolGateway.OnFailure += OnFailure;
			userpoolGateway.AuthenticateUser (email, password, onSuccess, onFailure);
		}

		public void RecentConfirmationCode (string email, string onSuccess, string onFailure)
		{
			throw new NotImplementedException ();
		}

		public void ChangePassword (string email, string oldPassword, string newPassword, string onSuccess, string onFailure)
		{
			throw new NotImplementedException ();
		}

		public void ForgotPassword (string email, string onSuccess, string onFailure)
		{
			throw new NotImplementedException ();
		}
	}
}

