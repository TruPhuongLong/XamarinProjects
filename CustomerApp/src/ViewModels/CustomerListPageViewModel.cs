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
        
		//COMMAND /Detail Command:
		Command<Customer> detailCommand;
		public Command<Customer> DetailCommand
		{
			get => detailCommand ?? (detailCommand = new Command<Customer>( customer => ExecuteCommand(customer) ));
		}
		async void ExecuteCommand(Customer customer)
        {
			await NavService.NavigateToViewModel<CustomerInfoPageViewModel, Customer>(customer);
        }

		//COMMAND /exit command:
		Command exitCommand;
        public Command ExitCommand
        {
            get => exitCommand ?? (exitCommand = new Command(ExecuteCommand));
        }
        async void ExecuteCommand()
        {
            // disconnect to signalR:
			await SignalRService.PosLeaveGroup();

            // pop to login customer page:
            await NavService.PreviousPage();
        }

		//COMMAND /Gift command:
		Command<Customer> giftCommand;
		public Command<Customer> GiftCommand
        {
			get => giftCommand ?? (giftCommand = new Command<Customer>(ExecuteGiftCommand));
        }
		async void ExecuteGiftCommand(Customer customer)
        {
			await NavService.NavigateToViewModel<CustomerEditPageViewModel, Customer>(customer);
        }

	}
}
