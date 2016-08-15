using Foundation;
using System;
using UIKit;
using cdeutsch;
using Core;

namespace UserPool_JSsdk_IOS
{
	public partial class SignupConfirmationViewController : UIViewController
	{
		public string email { get; set; }

		public SignupConfirmationViewController (IntPtr handle) : base (handle)
		{
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


			okBtn.TouchUpInside += (sender, e) => {

				if (confirmationCodeField.Text.Length == 0) {
					IOSUtilMethods.ShowAlertView ("Enter verification code");

				} else {

					var webManager = WebViewManager.GetInstance ();
					webManager.OnSuccess = OnConfirmEmailSuccess;
					webManager.OnFailure = OnConfirmEmailFailure;

					IOSUtilMethods.ShowProgressHud ();

					WebViewManager.GetInstance ().ConfirmRegistration (email, confirmationCodeField.Text, "onConfirmEmailSuccess", "onConfirmEmailFailure");

				}

			};


		}

		public void OnConfirmEmailSuccess (FireEventData arg)
		{
			IOSUtilMethods.HideProgressHud ();

			InvokeOnMainThread (() => {
				IOSUtilMethods.ShowAlertView ("Email is confirmed. You can login now.");

				var viewcontroller = Storyboard.InstantiateViewController ("SigninViewController") as SigninViewController;
				NavigationController.SetViewControllers (new [] { viewcontroller }, true);
			});

		}

		public void OnConfirmEmailFailure (FireEventData arg)
		{
			IOSUtilMethods.HideProgressHud ();



			InvokeOnMainThread (() => {
				IOSUtilMethods.ShowAlertView (Strings.ERROR_OCCURED);
			});


		}
	}
}