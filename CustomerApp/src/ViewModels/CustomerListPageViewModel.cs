using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using Xamarin.Forms;
using CustomerApp.src.redux.actions;

namespace CustomerApp.src.ViewModels
{
	public class CustomerListPageViewModel : BaseViewModel
	{
		private SignalRService SignalRService;
		//Implement abstrack class and  constructor:
        public override Task Init()
        {
            throw new NotImplementedException();
        }

		public CustomerListPageViewModel(ICustomerNavService navService, SignalRService signalRService) : base(navService)
        {
			SignalRService = signalRService;
			InitSignalR();
        } 

		//SIGNALR:
		private async void InitSignalR()
		{
			
			SignalRService.OnListCustomersChanged(action =>
			{
				CustomerStore.Dispath(action);
			});

			await SignalRService.PosJoinGroup();
		}
        
		//Detail Command:
		Command<Customer> detailCommand;
		public Command<Customer> DetailCommand
		{
			get => detailCommand ?? (detailCommand = new Command<Customer>( customer => ExecuteCommand(customer) ));
		}
		async void ExecuteCommand(Customer customer)
        {
			await NavService.NavigateToViewModel<CustomerInfoPageViewModel, Customer>(customer);
        }

	}
}
