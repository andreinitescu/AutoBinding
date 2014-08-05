// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace EasyBinding.Touch.Views
{
	[Register ("MainView")]
	partial class MainView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnLogin { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblUsername { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField txtUsername { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblUsername != null) {
				lblUsername.Dispose ();
				lblUsername = null;
			}

			if (btnLogin != null) {
				btnLogin.Dispose ();
				btnLogin = null;
			}

			if (txtUsername != null) {
				txtUsername.Dispose ();
				txtUsername = null;
			}
		}
	}
}
