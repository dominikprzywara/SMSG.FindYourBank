using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SMSG.FindYourBank.Data.ViewModels;

namespace SMSG.FindYourBank.Droid
{
	[Activity (Label = "SMSG.FindYourBank.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            var viewModel = new MainViewModel();
            var editText = FindViewById<EditText>(Resource.Id.myEditText);
            editText.TextChanged += (s, e) => viewModel.AccountNumber = editText.Text;
            var label = FindViewById<TextView>(Resource.Id.myTextView);
            viewModel.PropertyChanged += (s, e) => label.Text = viewModel.BankName;

			Button button = FindViewById<Button> (Resource.Id.myButton);
            button.Click += (s, e) => viewModel.Find();
            button.Text = viewModel.ButtonTitle;
		}
	}
}


