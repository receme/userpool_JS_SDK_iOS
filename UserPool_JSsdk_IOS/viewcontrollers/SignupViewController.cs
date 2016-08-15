using Foundation;
using System;
using UIKit;
using Core;
using cdeutsch;
using System.Diagnostics;

namespace UserPool_JSsdk_IOS
{
	public partial class SignupViewController : UIViewController, ISignupview
	{
		SignupViewPresenter presenter;
		WebViewManager webManager;
		string email;

		public SignupViewController (IntPtr handle) : base (handle)
		{
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			webManager = WebViewManager.GetInstance ();
			presenter = new SignupViewPresenter (this, webManager);

			signupBtn.TouchUpInside += (sender, e) => {

				email = emailField.Text;
				presenter.Signup (emailField.Text, passwordField.Text);

			};

			gotoSigninScreenBtn.TouchUpInside += (sender, e) => {

				var viewcontrolller = Storyboard.InstantiateViewController ("SigninViewController") as SigninViewController;
				NavigationController.SetViewControllers (new UIViewController [] { viewcontrolller }, false);

			};

		}

		public void ShowAlert (string message)
		{
			IOSUtilMethods.ShowAlertView (message);
		}

		public void ShowProgressView (string message = "Please wait...")
		{
			IOSUtilMethods.ShowProgressHud ();
		}

		public void HideProgressView ()
		{
			IOSUtilMethods.HideProgressHud ();
		}

		public void SetupCallbacks ()
		{
			webManager.OnSuccess = OnSignupSuccess;
			webManager.OnFailure = OnSignupFailure;
		}


		public void OnSignupSuccess (FireEventData arg)
		{
			HideProgressView ();

			Debug.WriteLine (arg.Data.ToString ());


			InvokeOnMainThread (() => {
				ShowAlert (Strings.VERIFICATION_CODE_SENT);

				var viewcontroller = Storyboard.InstantiateViewController ("SignupConfirmationViewController") as SignupConfirmationViewController;
				viewcontroller.email = email;
				NavigationController.PushViewController (viewcontroller, true); ;
			});



		}

		public void OnSignupFailure (FireEventData arg)
		{
			Debug.WriteLine (arg.Data.ToString ());

			HideProgressView ();

			InvokeOnMainThread (() => {
				ShowAlert (Strings.ERROR_OCCURED);
			});

		}



	}
}