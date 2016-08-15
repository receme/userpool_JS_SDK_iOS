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
    [Register ("SignupConfirmationViewController")]
    partial class SignupConfirmationViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField confirmationCodeField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton okBtn { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (confirmationCodeField != null) {
                confirmationCodeField.Dispose ();
                confirmationCodeField = null;
            }

            if (okBtn != null) {
                okBtn.Dispose ();
                okBtn = null;
            }
        }
    }
}