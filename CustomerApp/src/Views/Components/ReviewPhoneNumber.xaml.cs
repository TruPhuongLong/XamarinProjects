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
			BindableProperty.Create(nameof(PhoneNumber), typeof(string), typeof(ReviewPhoneNumber), default(string), BindingMode.TwoWay);
		public string PhoneNumber
		{
			set { SetValue(PhoneNumberProperty, value); }
			get { return (string)GetValue(PhoneNumberProperty); }
		}

		//BINDABLE /IsEnabled
		public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(ReviewPhoneNumber), default(bool), BindingMode.OneWay);
        public bool IsEnabled
        {
            get => (bool)GetValue(IsEnabledProperty);
            set { SetValue(IsEnabledProperty, value); }
        }
	}
}
