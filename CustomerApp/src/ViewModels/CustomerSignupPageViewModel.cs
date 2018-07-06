using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using Xamarin.Forms;
using CustomerApp.src.libs;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.redux.actions;

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

		private string phoneNumber;
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
            CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState(new Customer[] { }, true)));

			var isSuccess = await CustomerService.Post(customer);
			if(isSuccess)
			{
				// pop customerLoginPage
				await NavService.PreviousPage();
			}
			else
			{
				//notification signup fail
			}

			// trigger off indicator
			CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState(new Customer[] { }, false)));
		}
        
	}
}
