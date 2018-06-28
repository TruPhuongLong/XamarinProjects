using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public class CustomerSignupPageViewModel: BaseViewModel
    {
		// Implement BaseViewModel:
		public CustomerSignupPageViewModel(ICustomerNavService navService) : base(navService)
        {
			Customer = new Customer();
        }

		public override Task Init()
		{
			throw new NotImplementedException();
		}

        //PROP
		private Customer customer;
		public Customer Customer
		{
			get => customer;
            set 
			{
				SetProperty(ref customer, value);
				SignupCommand.ChangeCanExecute();
			}
		}

        //COMMAND
		private Command signupCommand;
		public Command SignupCommand
		{
			get => signupCommand ?? (signupCommand = new Command(ExecuteCommand, ValidateCommand));	
		}

		void ExecuteCommand()
		{
			Debug.WriteLine("signup command");
		}

		bool ValidateCommand()
		{
			return true;
		}
	}
}
