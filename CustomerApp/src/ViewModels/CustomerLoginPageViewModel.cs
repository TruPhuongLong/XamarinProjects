using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.libs;
using CustomerApp.src.Models;
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
			var response = await DataService.Get(Constants.URL_LOGIN_CUSTOMER + PhoneNumer);
			if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                
                // save info of user login:
				var Customer = JsonConvert.DeserializeObject<Customer>(content);

				Debug.WriteLine(JsonConvert.SerializeObject(Customer));

				//Navigate to CustomerInfoPage:

				//invoke SignalR
				await SignalRService.CustomerJoinGroup();
            }
		}
	}
}
