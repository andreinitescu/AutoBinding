using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore.Platform;

namespace EasyBinding.Core.ViewModels
{
	public class MainViewModel 
		: MvxViewModel
    {
		string username;
        public string Username
		{ 
			get { return this.username; }
			set { this.username = value; RaisePropertyChanged(() => this.Username); }
		}

		public IMvxCommand LoginCommand { get { return new MvxCommand (this.Login); } }

		void Login()
		{
			MvxTrace.Trace ("Logging in...");
		}
    }
}
