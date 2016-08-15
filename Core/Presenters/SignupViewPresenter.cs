using System;
namespace Core
{
	public class SignupViewPresenter
	{
		ISignupview view;
		IWebviewmanager webviewManager;

		public SignupViewPresenter (ISignupview _view, IWebviewmanager _webviewManager)
		{
			view = _view;
			webviewManager = _webviewManager;
		}

		public void Signup (string email, string password)
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

			webviewManager.Signup (email, password, "onSignupSuccess", "onSignupFailure");
		}
	}
}

