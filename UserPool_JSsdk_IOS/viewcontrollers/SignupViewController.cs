using Foundation;
using System;
using UIKit;
using Core;
using cdeutsch;

namespace UserPool_JSsdk_IOS
{
	public partial class SignupViewController : UIViewController, ISignupview
	{
		SignupViewPresenter presenter;
		WebViewManager webManager;

		public SignupViewController (IntPtr handle) : base (handle)
		{
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			webManager = WebViewManager.GetInstance ();
			presenter = new SignupViewPresenter (this, webManager);

			signupBtn.TouchUpInside += (sender, e) => {
				presenter.Signup (emailField.Text, passwordField.Text);

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
			webManager.OnSuccess += OnSignupSuccess;
			webManager.OnFailure += OnSignupFailure;
		}


		public void OnSignupSuccess (FireEventData arg)
		{

			ShowAlert (arg.Data.ToString ());
			var viewcontroller = Storyboard.InstantiateViewController ("SignupConfirmationViewController") as SignupConfirmationViewController;
			NavigationController.PushViewController (viewcontroller, true);

		}

		public void OnSignupFailure (FireEventData arg)
		{
			ShowAlert (arg.Data.ToString ());

		}


	}
}