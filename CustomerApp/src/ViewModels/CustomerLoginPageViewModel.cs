using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.libs;
using CustomerApp.src.Models;
using CustomerApp.src.redux.actions;
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
		private SignalRService SignalRService;

		public CustomerLoginPageViewModel(ICustomerNavService navService, DataService dataService, SignalRService signalRService): base(navService)
        {
			DataService = dataService;
			SignalRService = signalRService;
        }

		public override Task Init()
		{
			throw new NotImplementedException();
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
            CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState(new Customer[] { }, true)));

			var response = await DataService.Get(Constants.URL_LOGIN_CUSTOMER + PhoneNumer);

			// response.IsSuccessStatusCode : it mean this customer exist on database and we get customer info from his phoneNumber.
            // from customer info, we send to signalR to Pos update his infomation.
			if (response != null && response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

				//invoke SignalR
				await SignalRService.CustomerJoinGroup(content);
                
				//Navigate to CustomerInfoPage:
				var customer = JsonConvert.DeserializeObject<Customer>(content);
				await NavService.NavigateToViewModel<CustomerInfoPageViewModel, Customer>(customer);
			}else{
				await NavService.NavigateToViewModel<CustomerSignupPageViewModel, string>(PhoneNumer);
			}

			//clear phoneNumber:
			PhoneNumer = "";

			// trigger off indicator
			CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState(new Customer[] { }, false)));
		}
	}
}
