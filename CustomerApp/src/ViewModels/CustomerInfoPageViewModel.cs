using System;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public class CustomerInfoPageViewModel : BaseViewModel<Customer>
	{
		SignalRService SignalRService;

		// Implement BaseViewModel<Customer>
		public CustomerInfoPageViewModel(ICustomerNavService navService, SignalRService signalRService) : base(navService)
		{
			SignalRService = signalRService;
		}

		public override async Task Init(Customer customerInput)
		{
			await Task.Run(() =>
               Customer = customerInput
		    );
		}


		// Business for CustomerDetailPage:
		Customer customer;
		public Customer Customer
		{
			get => customer;
			set
			{
				SetProperty(ref customer, value);
			}
		}

		Command exitCommand;
		public Command ExitCommand
		{
			get => exitCommand ?? (exitCommand = new Command(ExecuteCommand));
		}
		async void ExecuteCommand()
        {
			// disconnect to signalR:
			await SignalRService.CustomerLeaveGroup(Customer.ID.ToString());

			// pop to login customer page:
			await NavService.PreviousPage();
        }
	}
}
