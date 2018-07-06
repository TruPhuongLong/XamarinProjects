using System;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using Xamarin.Forms;
using CustomerApp.src.libs;
using CustomerApp.src.redux.actions;

namespace CustomerApp.src.ViewModels
{
	public class EntryPageViewModel : BaseViewModel
	{
		// Implement BaseViewModel:
		public EntryPageViewModel(ICustomerNavService navService) : base(navService)
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
            CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState(new Customer[] { }, true)));

			await NavService.NavigateToViewModel<CustomerListPageViewModel>();

			// set Enviroment:
            await LocalStorage.SetEnviroment(Constants.POS_ENV);

			// trigger off indicator
            CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState(new Customer[] { }, false)));
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
            CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState(new Customer[] { }, true)));

            await NavService.NavigateToViewModel<CustomerLoginPageViewModel>();

			// set Enviroment:
			await LocalStorage.SetEnviroment(Constants.CUSTOMER_ENV);

			// trigger off indicator
			CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState(new Customer[] { }, false)));
        }

	}
}
