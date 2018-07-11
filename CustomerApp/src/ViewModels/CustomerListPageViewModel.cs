using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using Xamarin.Forms;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.store;

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
				//((CustomerStore)CustomerStore).Dispath_Notification("new Customer come in");
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
        
		//COMMAND /Gift command:
		Command<Tuple<Customer, string>> giftCommand;
		public Command<Tuple<Customer, string>> GiftCommand
        {
			get => giftCommand ?? (giftCommand = new Command<Tuple<Customer, string>>(ExecuteGiftCommand));
        }
		async void ExecuteGiftCommand(Tuple<Customer, string> tuple)
        {
			await NavService.NavigateToViewModel<CustomerEditPageViewModel, Tuple<Customer, string>>(tuple);
        }

		//COMMAND /delete list
		Command clearCommand;
		public Command ClearCommand
		{
			get => clearCommand ?? (clearCommand = new Command(ExecuteClearCommand));
		}
		async void ExecuteClearCommand()
		{
			await SignalRService.ClearCustomers();
		}

		//COMMAND /SettingCommand
		Command settingCommand;
		public Command SettingCommand
        {
			get => settingCommand ?? (settingCommand = new Command(ExecuteSettingCommand));
        }
		void ExecuteSettingCommand()
        {

        }

	}
}
