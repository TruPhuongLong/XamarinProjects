using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using Xamarin.Forms;
using CustomerApp.src.libs;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.store;

namespace CustomerApp.src.ViewModels
{
	public class CustomerSignupPageViewModel: BaseViewModel<string>
    {
		private CustomerService CustomerService;
		// Implement BaseViewModel:
		public CustomerSignupPageViewModel(ICustomerNavService navService, CustomerService customerService) : base(navService)
        {
			CustomerService = customerService;
        }

		public override Task Init(string parameter)
		{
			return Task.Run(() => PhoneNumber = parameter);
		}

		private string phoneNumber = "099999";
		public string PhoneNumber
		{
			get => phoneNumber;
			set
			{
				SetProperty(ref phoneNumber, value);
			}
		}

        //COMMAND
		private Command<Customer> signupCommand;
		public Command<Customer> SignupCommand
		{
			get => signupCommand ?? (signupCommand = new Command<Customer>(ExecuteCommand));	
		}

		async void ExecuteCommand(Customer customer)
		{
			// trigger up indicator
			((CustomerStore)CustomerStore).Dispath_Indicator(true);

			var isSuccess = await CustomerService.Post(customer);
			if(isSuccess)
			{
				// pop customerLoginPage
				await NavService.PreviousPage();
				((CustomerStore)CustomerStore).Dispath_Notification("save success");
			}
			else
			{
				//notification signup fail
			}

			// trigger off indicator
			((CustomerStore)CustomerStore).Dispath_Indicator(false);
		}








		//COMMAND
        private Command backCommand;
        public Command BackCommand
        {
			get => backCommand ?? (backCommand = new Command(Execute_BackCommand));
        }
        void Execute_BackCommand()
		{
			
		}


		//COMMAND
        private Command skipCommand;
        public Command SkipCommand
        {
			get => skipCommand ?? (skipCommand = new Command(Execute_SkipCommand));
        }
		void Execute_SkipCommand()
        {

        }

        
		//COMMAND
        private Command continueCommand;
		public Command ContinueCommand
        {
			get => continueCommand ?? (continueCommand = new Command(Execute_ContinueCommand));
        }
		void Execute_ContinueCommand()
        {

        }
        
	}
}
