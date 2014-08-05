using System;
using System.Linq;
using Cirrious.MvvmCross.Binding.BindingContext;
using System.Reflection;
using MonoTouch.Foundation;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.UIKit;
using EasyBinding.Core.ViewModels;
using EasyBinding.Touch.Views;
using System.Collections.Generic;
using Cirrious.CrossCore.Platform;

namespace EasyBinding.Touch.Tools
{
	public static class AutoBinder
	{
		public static void AutoBind<TTarget>(this TTarget target) where TTarget : class, IMvxBindingContextOwner 
		{
			// get all outlets
			var outlets = target.GetType ().GetProperties (BindingFlags.Instance | BindingFlags.NonPublic).Where (pi => pi.CustomAttributes.Any (cad => cad.AttributeType == typeof(OutletAttribute))).ToList ();
			foreach (PropertyInfo pi in outlets) {
				AutoBind<TTarget> (target, pi);
			}
		}

		public static void AutoBind<TTarget>(this TTarget target, object outlet, string outletName) where TTarget : class, IMvxBindingContextOwner
		{
			var viewModel = target.BindingContext.DataContext;
			//var vmProperties = viewModel.GetType ().GetProperties ().ToList();

			if (typeof(UIButton).IsInstanceOfType (outlet)) {
				// bind UIButton to command
				var propertyName = string.Format ("{0}Command", outletName.Substring (3)); // skip 'btn' from outlet name

				//var vmPi = viewModel.GetType ().GetProperty (commandName);
				//if (vmPi != null /*&& vmPi.PropertyType.IsSubclassOf(IMvxCommand)*/) 
				target.AddBindings (new Dictionary<object, string> () {
					{ outlet, string.Format ("Tap {0}", propertyName) },
				}); 
				MvxTrace.Trace (MvxTraceLevel.Diagnostic, "Auto-bound {0} to {1}", outletName, propertyName);
			} else if (typeof(UITextField).IsInstanceOfType (outlet)) {
				// bind UITextField to property
				var propertyName = outletName.Substring (3); // skip 'txt' from outlet name
				target.AddBindings (new Dictionary<object, string> () {
					{ outlet, string.Format ("Text {0}, Mode=TwoWay", propertyName) },
				});
				MvxTrace.Trace (MvxTraceLevel.Diagnostic, "Auto-bound {0} to {1}", outletName, propertyName);
			}
			else if (typeof(UILabel).IsInstanceOfType (outlet)) {
				// bind UILabel to property
				var propertyName = outletName.Substring (3); // skip 'lbl' from outlet name
				target.AddBindings (new Dictionary<object, string> () {
					{ outlet, string.Format ("Text {0}", propertyName) },
				});
				MvxTrace.Trace (MvxTraceLevel.Diagnostic, "Auto-bound {0} to {1}", outletName, propertyName);
			}
		}

		static void AutoBind<TTarget>(TTarget target, PropertyInfo piOutlet) where TTarget : class, IMvxBindingContextOwner
		{
			var outlet = piOutlet.GetValue (target);
			target.AutoBind<TTarget> (outlet, piOutlet.Name);
		}
	}
}

