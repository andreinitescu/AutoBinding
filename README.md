AutoBinding
===========

The purpose is to make MvvmCross bindings in iOS easier.


How does it work?
-----------------

Based on a simple name convention, it creates MvvmCross bindings at runtime depending on the outlet type.

For example, if you have a UIButton outlet called btnLogin, it's bound to view-model LoginCommand property.


Naming rules
-----------------

- An UIButton outlet with the name 'btnXXX' is bound to the view-model 'XXXCommand' property.

- An UITextField outlet with the name 'txtXXX' is bound to the view-model 'XXX' property.

- An UILabel outlet with the name 'lblXXX' is bound to the view-model 'XXX' property.


Code example
-------------

In your view-controller for example, you just need to call:

    using EasyBinding.Tools;
    
    public override void ViewDidLoad () 
    {
		base.ViewDidLoad ();
		this.AutoBind();
    }
    
The implementation is in the extension class in EasyBinding.Touch/Tools/AutoBinder.cs

You can check the application output to see which auto bindings were created:

	2014-08-05 15:18:33.411 EasyBindingTouch[1620:70b] mvx:Diagnostic:  0.20 Auto-bound btnLogin to LoginCommand
	mvx:Diagnostic:  0.20 Auto-bound btnLogin to LoginCommand
	2014-08-05 15:18:33.413 EasyBindingTouch[1620:70b] mvx:Diagnostic:  0.20 Auto-bound lblUsername to Username
	mvx:Diagnostic:  0.20 Auto-bound lblUsername to Username
	2014-08-05 15:18:33.423 EasyBindingTouch[1620:70b] mvx:Diagnostic:  0.21 Auto-bound txtUsername to Username
	mvx:Diagnostic:  0.21 Auto-bound txtUsername to Username

If you wish to have more control, you can auto bind a specific outlet:

    public override void ViewDidLoad () 
    {
		base.ViewDidLoad ();
		this.AutoBind("btnLogin");
    }



Under the hood
--------------

It's very easy, using reflection it's getting a list of all the outlets, which are private properties of the view-controller with OutletAttribute attribute.

For each of the outlets, it's checking the type, and based on it, it's creating the MvvmCross bindings.

