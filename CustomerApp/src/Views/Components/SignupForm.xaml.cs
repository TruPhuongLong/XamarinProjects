using System;
using System.Collections.Generic;
using CustomerApp.src.Models;
using Xamarin.Forms;
using CustomerApp.src.libs;

namespace CustomerApp.src.Views.Components
{
    public partial class SignupForm : ContentView
    {
		//BINDABLE
		public static readonly BindableProperty MainPhoneProperty =
			BindableProperty.Create(nameof(MainPhone), typeof(string), typeof(SignupForm), default(string), BindingMode.TwoWay);
		public string MainPhone
        { 
			get { return (string)GetValue(MainPhoneProperty); }
			set { SetValue(MainPhoneProperty, value); }
		}


		//PROPS
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Month { get; set; }
		public string Day { get; set; }
		public string Year { get; set; }

        public SignupForm()
        {
            InitializeComponent();
        }

		//EVENT
		void OnSignupClicked(object sender, EventArgs args)
        {
			var customer = new Customer 
			{ 
				MainPhone = MainPhone,
				Email = Email,
				Name = FirstName + " " + LastName
			};
			if(!string.IsNullOrEmpty(Day) || !string.IsNullOrEmpty(Month) || !string.IsNullOrEmpty(Year))
			{
				var (isValidateSuccess, dayOfBirth) = FuncHelp.ValidateDateTime(Year, Month, Day);
                if (isValidateSuccess)
                {
                    customer.DateOfBirth = (DateTime)dayOfBirth;
                }
                else
                {
					//notification error:

                    //then return
					return;
                }
			}
			Execute(Command, customer);
        }

        //BINDABLE /command
		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(Command<Customer>), typeof(SignupForm), null);

		public Command<Customer> Command
        {
			get { return (Command<Customer>)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        
        // Helper method for invoking commands savely
		public void Execute(Command<Customer> command, Customer customer)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
				command.Execute(customer);
            }
        }
    }
}
