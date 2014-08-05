
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using Cirrious.MvvmCross.Binding.BindingContext;
using EasyBinding.Touch.Tools;

namespace EasyBinding.Touch.Views
{
	public partial class MainView : BaseViewController
	{
		public MainView () : base ("MainView", null)
		{
		}
	}
}

