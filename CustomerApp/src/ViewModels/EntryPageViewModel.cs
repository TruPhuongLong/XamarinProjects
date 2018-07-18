using System;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using Xamarin.Forms;
using CustomerApp.src.libs;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.store;
using CustomerApp.src.Services.signalRService;

namespace CustomerApp.src.ViewModels
{
	public class EntryPageViewModel : BaseViewModel
	{
		private SignalRService2 SignalRService;
		// Implement BaseViewModel:
		public EntryPageViewModel(ICustomerNavService navService, SignalRService2 signalRService) : base(navService)
		{
		}

		public override Task Init()
		{
			throw new NotImplementedException();
		}

        //COMMAND //push CustomerListPage
		Command pushCustomerListPage;
		public Command PushCustomerListPage
		{
			get => pushCustomerListPage ?? (pushCustomerListPage = new Command(ExecuteCommand_PushCustomerListPage));
		}
		async void ExecuteCommand_PushCustomerListPage()
		{
			// trigger up indicator
			((CustomerStore)CustomerStore).Dispath_Indicator(true);


			await NavService.NavigateToViewModel<CustomerListPageViewModel>();

            // set Enviroment:
            await LocalStorage.SetEnviroment(Constants.POS_ENV);
         
			// trigger off indicator
			((CustomerStore)CustomerStore).Dispath_Indicator(false);
		}
        
        //COMMAND /push CustomerLoginPage
		Command pushCustomerLoginPage;
		public Command PushCustomerLoginPage
        {
			get => pushCustomerLoginPage ?? (pushCustomerLoginPage = new Command(ExecuteCommand_PushCustomerLoginPage));
        }
		async void ExecuteCommand_PushCustomerLoginPage()
        {
			// trigger up indicator
			((CustomerStore)CustomerStore).Dispath_Indicator(true);
            
			await NavService.NavigateToViewModel<CustomerLoginPageViewModel>();

            // set Enviroment:
            await LocalStorage.SetEnviroment(Constants.CUSTOMER_ENV);
            

			// trigger off indicator
			((CustomerStore)CustomerStore).Dispath_Indicator(false);
        }

		//COMMAND /sign out
		Command signout;
		public Command Signout
		{
			get => signout ?? (signout = new Command(ExecuteCommand_Signout));	
		}
		async void ExecuteCommand_Signout()
		{
			await LocalStorage.Reset();
			await NavService.PreviousPage();
		}



	}
}
