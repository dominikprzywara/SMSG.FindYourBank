using SMSG.FindYourBank.Data.ViewModels;
using System;

using UIKit;

namespace SMSG.FindYourBank.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            var viewModel = new MainViewModel();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.SetTitle(viewModel.ButtonTitle, UIControlState.Normal);
            Button.TouchUpInside += (s, e) => viewModel.Find();

            viewModel.PropertyChanged += (s, e) => Label.Text = viewModel.BankName;
            TextBox.EditingChanged += (s, e) => viewModel.AccountNumber = TextBox.Text;
            TextBox.Placeholder = viewModel.Hint;
		}
	}
}

