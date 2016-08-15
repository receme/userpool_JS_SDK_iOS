using Foundation;
using System;
using UIKit;
using Core;
using cdeutsch;

namespace UserPool_JSsdk_IOS
{
	public partial class SigninViewController : UIViewController, ISigninview
	{
		SigninViewPresenter presenter;
		WebViewManager webManager;

		public SigninViewController (IntPtr handle) : base (handle)
		{
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			webManager = WebViewManager.GetInstance ();
			presenter = new SigninViewPresenter (this, webManager);
		}


		partial void OnClick_Signin (UIButton sender)
		{
			presenter.Login (emailField.Text, passwordField.Text);
		}

		partial void Onclick_gotoSignup (UIButton sender)
		{
			var viewcontroller = Storyboard.InstantiateViewController ("SignupViewController") as SignupViewController;
			NavigationController.SetViewControllers (new UIViewController [] { viewcontroller }, false);
		}

		public void ShowAlert (string message)
		{
			IOSUtilMethods.ShowAlertView (message);

		}

		public void ShowProgressView (string message)
		{
			IOSUtilMethods.ShowProgressHud ();
		}

		public void HideProgressView ()
		{
			IOSUtilMethods.HideProgressHud ();
		}

		public void OnSigninSuccess (FireEventData arg)
		{

			//arg contains token for this user login
			//you can now set this token in cognito credential to perform other operations.

			//Something like this

			//var credential = new CognitoAWSCredentials (
			//	AWSConstants.IDENTITY_POOL_ID,
			//	RegionEndpoint.USEast1
			//);

			//credential.AddLogin (AWSConstants.USER_POOL_PROVIDER, token);




			HideProgressView ();

			NSUserDefaults.StandardUserDefaults.SetBool (true, Strings.IS_LOGGEDIN);
			NSUserDefaults.StandardUserDefaults.Synchronize ();

			InvokeOnMainThread (() => {
				var viewcontroller = Storyboard.InstantiateViewController ("WelcomeViewController") as WelcomeViewController;
				viewcontroller.email = emailField.Text;
				NavigationController.SetViewControllers (new UIViewController [] { viewcontroller }, true);
			});



		}

		public void OnSigninFailure (FireEventData arg)
		{

			HideProgressView ();

			InvokeOnMainThread (() => {
				ShowAlert ("Login failed");
			});

		}

		public void SetupCallbacks ()
		{
			webManager.OnSuccess = OnSigninSuccess;
			webManager.OnFailure = OnSigninFailure;
		}
	}
}