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
    [Register ("SigninViewController")]
    partial class SigninViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField emailField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton gotoSignupScreenBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passwordField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton signinBtn { get; set; }

        [Action ("Onclick_gotoSignup:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Onclick_gotoSignup (UIKit.UIButton sender);

        [Action ("OnClick_Signin:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OnClick_Signin (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (emailField != null) {
                emailField.Dispose ();
                emailField = null;
            }

            if (gotoSignupScreenBtn != null) {
                gotoSignupScreenBtn.Dispose ();
                gotoSignupScreenBtn = null;
            }

            if (passwordField != null) {
                passwordField.Dispose ();
                passwordField = null;
            }

            if (signinBtn != null) {
                signinBtn.Dispose ();
                signinBtn = null;
            }
        }
    }
}