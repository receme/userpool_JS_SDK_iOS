using System;
using UIKit;
using MBProgressHUD;
namespace UserPool_JSsdk_IOS
{
	public class IOSUtilMethods
	{
		static MTMBProgressHUD progress;

		public static void ShowAlertView (string message)
		{
			var alert = new UIAlertView ("", message, null, "Ok", null);
			alert.Show ();
		}

		public static void ShowProgressHud (string message = "Please wait...")
		{
			if (progress == null) {
				progress = new MTMBProgressHUD ();
			}
			progress.DimBackground = true;
			progress.LabelText = message;
			progress.Show (true);
			UIApplication.SharedApplication.KeyWindow.AddSubview (progress);
		}

		public static void HideProgressHud ()
		{
			if (progress != null) {
				progress.Hide (true);

			}
		}


	}
}

