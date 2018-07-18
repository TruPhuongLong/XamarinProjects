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
using CustomerApp.src.libs;

namespace CustomerApp.src.ViewModels
{
	public class CustomerListPageViewModel : BaseViewModel
	{
		private SignalRService2 SignalRService;
		//Implement abstrack class and  constructor:
        public override Task Init()
        {
            throw new NotImplementedException();
        }

		public CustomerListPageViewModel(ICustomerNavService navService, SignalRService2 signalRService) : base(navService)
        {
			SignalRService = signalRService;
			InitSignalR();
        } 

		//SIGNALR:
		private async void InitSignalR()
		{
			SignalRService.OnCustomerChanged(action =>
			{
				CustomerStore.Dispath(action);
			});

			await JoinGroup();
		}
        
		//COMMAND /change point command:
		Command<string> changePointCommand;
		public Command<string> ChangePointCommand
        {
			get => changePointCommand ?? (changePointCommand = new Command<string>(Execute_ChangePointCommand));
        }
		async void Execute_ChangePointCommand(string styleid)
        {
			await NavService.NavigateToViewModel<CustomerEditPageViewModel, string>(styleid);
        }
        
		//COMMAND /no point command:
        Command noChangePointCommand;
        public Command NoChangePointCommand
        {
			get => noChangePointCommand ?? (noChangePointCommand = new Command(Execute_NoChangePointCommand));
        }
		async void Execute_NoChangePointCommand()
        {
			await NavService.PreviousPage();
        }


		private async Task<bool> JoinGroup()
        {
            var isJoinSuccess = await SignalRService.JoinGroup();
            if (!isJoinSuccess)
            {
                ((CustomerStore)CustomerStore).Dispath_Notification("not connection");
                return true;
            }
            return false;
        }
	}
}
