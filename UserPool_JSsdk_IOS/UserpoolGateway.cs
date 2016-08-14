using System;
using cdeutsch;
using Core;
using UIKit;

namespace UserPool_JSsdk_IOS
{
	public class UserpoolGateway : IUserpoolgateway
	{
		UIWebView webview;
		public Action<FireEventData> OnSuccess;
		public Action<FireEventData> OnFailure;

		public UserpoolGateway (UIWebView _webview)
		{
			webview = _webview;
		}

		public void Signup (string email, string password, string onSuccess, string onFailure)
		{
			webview.AddEventListener (onSuccess, OnSuccess);
			webview.AddEventListener (onFailure, OnFailure);

			webview.EvaluateJavascript (String.Format ("Client.signUp('{0}','{1}','{2}','{3}');", email, password, onSuccess, onFailure));

		}

		public void ConfirmRegistration (string email, string code, string onSuccess, string onFailure)
		{

			webview.AddEventListener (onSuccess, OnSuccess);
			webview.AddEventListener (onFailure, OnFailure);

			webview.EvaluateJavascript (String.Format ("Client.confirmRegistration('{0}','{1}','{2}','{3}');", email, code, onSuccess, onFailure));

		}

		public void AuthenticateUser (string email, string password, string onSuccess, string onFailure)
		{
			webview.AddEventListener (onSuccess, OnSuccess);
			webview.AddEventListener (onFailure, OnFailure);

			webview.EvaluateJavascript (String.Format ("Client.authenticateUser('{0}','{1}','{2}','{3}');", email, password, onSuccess, onFailure));
		}

		public void ChangePassword (string email, string oldPassword, string newPassword, string onSuccess, string onFailure)
		{
			throw new NotImplementedException ();
		}

		public void ForgotPassword (string email, string onSuccess, string onFailure)
		{
			throw new NotImplementedException ();
		}

		public void RecentConfirmationCode (string email, string onSuccess, string onFailure)
		{
			throw new NotImplementedException ();
		}


	}
}

