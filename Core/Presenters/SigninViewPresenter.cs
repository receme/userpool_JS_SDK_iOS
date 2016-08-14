using System;
namespace Core
{
	public class SigninViewPresenter
	{
		ISigninview view;
		IWebviewmanager webviewManager;

		public SigninViewPresenter (ISigninview _view, IWebviewmanager _webviewManager)
		{
			view = _view;
			webviewManager = _webviewManager;
		}

		public void Init ()
		{

		}

		public void Login (string email, string password)
		{
			if (email.Length == 0 || password.Length == 0) {
				view.ShowAlert (Strings.EMAIL_PASSWORD_REQUIRED);
				return;
			}

			if (!UtilMethods.IsEmailValid (email)) {
				view.ShowAlert (Strings.EMAIL_NOT_VALID);
				return;
			}

			view.ShowProgressView ();

			view.SetupCallbacks ();

			webviewManager.AuthenticateUser (email, password, "onSigninSuccess", "onSigninFailure");

			view.HideProgressView ();


		}
	}
}

