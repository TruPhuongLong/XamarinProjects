using System;
using System.Collections.Generic;
using CustomerApp.src.Models;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class SignupForm : ContentView
    {
		//PROPS
		public string MainPhone { get; set; }
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
			Execute(Command, new Customer 
			{ 
			
			});
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
