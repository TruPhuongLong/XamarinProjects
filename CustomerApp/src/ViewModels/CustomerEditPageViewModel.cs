using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public class CustomerEditPageViewModel: BaseViewModel<Customer>
    {
		private CustomerService CustomerService;
		private SignalRService SignalRService;
		public CustomerEditPageViewModel(ICustomerNavService navService, CustomerService customerService, SignalRService signalRService): base(navService)
        {
			CustomerService = customerService;
			SignalRService = signalRService;
        }

		public override Task Init(Customer parameter)
		{
			return Task.Run(() => {
				Customer = parameter;
				CurrentPoints = Customer.CurrentPoints;	
			});
		}

        //PROP
		private float currentPoints;
		public float CurrentPoints
        {
			get => currentPoints;
			set { SetProperty(ref currentPoints, value); }
        }

        //PROP
		private Customer customer;
		public Customer Customer
		{
			get => customer;
			set { SetProperty(ref customer, value); }
		}

		//COMMAND
		private Command saveCommand;
		public Command SaveCommand
		{
			get => saveCommand ?? (saveCommand = new Command(ExecuteCommand));
		}
		async void ExecuteCommand()
		{
			Debug.WriteLine(CurrentPoints);
			var newCustomer = Customer;
			newCustomer.CurrentPoints = CurrentPoints;
			var CustomerEdited = await CustomerService.Put(newCustomer);

			if(CustomerEdited != null)
			{
				await NavService.PreviousPage();
				await SignalRService.CustomerLeaveGroup(newCustomer.ID.ToString());
			}
			else
			{
				// fail to save edit:
			}
		}
	}
}
