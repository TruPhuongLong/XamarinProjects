using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
	public partial class EntryPhoneNumber : ContentView
	{
		//BINDABLE /for binding:
		public static readonly BindableProperty PhoneNumberProperty =
			BindableProperty.Create(
			    "PhoneNumber",
			    typeof(string),
			    typeof(EntryPhoneNumber),
                ""
		);

		//PROP
		public string PhoneNumber
		{
			get { return (string)GetValue(PhoneNumberProperty); }
			set { SetValue(PhoneNumberProperty, value); }
		}

		//PROP
		public int SizeButton { get; set; } = 100;

		//CONSTRUCTOR
		public EntryPhoneNumber()
		{
			InitializeComponent();
		}

		//FUNC /number pick
		void OnPickNumber(object sender, EventArgs args)
		{
			Button btn = (Button)sender;
			switch (btn.StyleId)
			{
				case "Delete":
					Delete();
					break;
				case "Clear":
					Clear();
					break;
				default:
					Add(btn.StyleId);
					break;
			}
		}

		//FUNC /Delete /private 
		private void Delete()
		{
			if (PhoneNumber == null) return;
			if (PhoneNumber.Length <= 0) return;
			var endIndex = PhoneNumber.Length - 1;
			var newPhoneNumber = PhoneNumber.Substring(0, endIndex);
			PhoneNumber = newPhoneNumber;
		}

		//FUNC /Clear /private 
		private void Clear()
		{
			if (PhoneNumber == "") return;
			PhoneNumber = "";
		}

		//FUNC /Add /private 
		private void Add(string styleId)
		{
			//only add when phoneNumber is <= 10 length:
			if (PhoneNumber.Length > 10) return;
			PhoneNumber = PhoneNumber + styleId;
		}



	}
}
