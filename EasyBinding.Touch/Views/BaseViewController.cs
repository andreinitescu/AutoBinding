using System;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using EasyBinding.Touch.Tools;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.Foundation;

namespace EasyBinding.Touch.Views
{
	public class BaseViewController : MvxViewController
	{
		public BaseViewController (string nibName, NSBundle bundle) : base (nibName, bundle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// ios7 layout
			if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
				EdgesForExtendedLayout = UIRectEdge.None;

			this.CreateBindings ();
		}

		protected virtual void CreateBindings()
		{
			this.AutoBind ();
		}
	}
}

