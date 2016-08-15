using Foundation;
using System;
using UIKit;
using Core;

namespace UserPool_JSsdk_IOS
{
	public partial class WelcomeViewController : UIViewController
	{
		public string email { get; set; }

		public WelcomeViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			welcomeLabel.Text = welcomeLabel.Text + " " + email;

			signoutBtn.TouchUpInside += (sender, e) => {

				var viewcontroller = Storyboard.InstantiateViewController ("SigninViewController") as SigninViewController;
				NavigationController.SetViewControllers (new UIViewController [] { viewcontroller }, true);

				NSUserDefaults.StandardUserDefaults.SetBool (false, Strings.IS_LOGGEDIN);
				NSUserDefaults.StandardUserDefaults.Synchronize ();

			};

		}
	}
}