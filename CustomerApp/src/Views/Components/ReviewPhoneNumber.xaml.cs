using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
	public partial class ReviewPhoneNumber : ContentView
	{
		public ReviewPhoneNumber()
		{
			InitializeComponent();
		}

		//PROP
        public int SizeButton { get; set; } = 100;

		void OnNextClicked(object sender, EventArgs args)
		{
			Execute(Command);
		}


		//BINDABLE /command
		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ReviewPhoneNumber), null);
		
		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		// Helper method for invoking commands savely
		public void Execute(ICommand command)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
				command.Execute(null);
            }
        }


		//BINDABLE /PhoneNumberfor binding:
		public static readonly BindableProperty PhoneNumberProperty =
			BindableProperty.Create(
				"PhoneNumber",
			    typeof(string),
				typeof(ReviewPhoneNumber),
			    "",
    			propertyChanged: (bindable, oldValue, newValue) =>
    		   {
    			   // Set the label.
    			   ReviewPhoneNumber reviewPhoneNumber = (ReviewPhoneNumber)bindable;
    			   reviewPhoneNumber.labelPhoneNumber.Text = (string)newValue; 
    		   }
		    );

		public string PhoneNumber
		{
			set { SetValue(PhoneNumberProperty, value); }
			get { return (string)GetValue(PhoneNumberProperty); }
		}


	}
}
