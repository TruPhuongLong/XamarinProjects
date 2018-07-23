using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.libs;
using CustomerApp.src.Models;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.store;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public class CustomerLoginPageViewModel: BaseViewModel
    {
		private DataService DataService;
		private SignalRService2 SignalRService;

		public CustomerLoginPageViewModel(ICustomerNavService navService, DataService dataService, SignalRService2 signalRService): base(navService)
        {
			DataService = dataService;
			SignalRService = signalRService;
			Init();
        }

		public override async Task Init()
		{
			await InitSignalR();
		}

		//SIGNALR:
        private async Task InitSignalR()
        {
            SignalRService.OnCustomerChanged(action =>
            {
                CustomerStore.Dispath(action);
            });
            
            await JoinGroup();
        }

		private async Task<bool> JoinGroup()
        {
            var isJoinSuccess = await SignalRService.JoinGroup();
            if (!isJoinSuccess)
            {
                ((CustomerStore)CustomerStore).Dispath_Notification("not connection");
                return false;
            }
            return true;
        }

		string phoneNumer;
		public string PhoneNumer
		{
			get => phoneNumer;
			set
			{
				SetProperty(ref phoneNumer, value);
			}
		}

		//COMMAND
		Command customerLoginCommand;
		public Command CustomerLoginCommand
		{
			get => customerLoginCommand ?? (customerLoginCommand = new Command(ExecuteCommand_CustomerLoginCommand));
		}
		async void ExecuteCommand_CustomerLoginCommand()
		{
			// trigger up indicator
			CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState(isRunningIndicator: true)));

			var response = await DataService.Get(Constants.URL_LOGIN_CUSTOMER + PhoneNumer);

			// response.IsSuccessStatusCode : it mean this customer exist on database and we get customer info from his phoneNumber.
            // from customer info, we send to signalR to Pos update his infomation.
			if (response != null && response.IsSuccessStatusCode)
            {
				var content = await response.Content.ReadAsStringAsync();

				await SignalRService.CustomersChanged(content);

				await NavService.NavigateToViewModel<CustomerInfoPageViewModel>();
			}else{
				await NavService.NavigateToViewModel<CustomerSignupPageViewModel, string>(PhoneNumer);
			}

			//clear phoneNumber:
			PhoneNumer = "";

			// trigger off indicator
			CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState()));

		}



	}
}
