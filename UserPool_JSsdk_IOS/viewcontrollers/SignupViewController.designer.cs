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
    [Register ("SignupViewController")]
    partial class SignupViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField emailField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton gotoSigninScreenBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passwordField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton signupBtn { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (emailField != null) {
                emailField.Dispose ();
                emailField = null;
            }

            if (gotoSigninScreenBtn != null) {
                gotoSigninScreenBtn.Dispose ();
                gotoSigninScreenBtn = null;
            }

            if (passwordField != null) {
                passwordField.Dispose ();
                passwordField = null;
            }

            if (signupBtn != null) {
                signupBtn.Dispose ();
                signupBtn = null;
            }
        }
    }
}