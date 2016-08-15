// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace UserPool_JSsdk_IOS
{
    [Register ("WelcomeViewController")]
    partial class WelcomeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton signoutBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel welcomeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (signoutBtn != null) {
                signoutBtn.Dispose ();
                signoutBtn = null;
            }

            if (welcomeLabel != null) {
                welcomeLabel.Dispose ();
                welcomeLabel = null;
            }
        }
    }
}