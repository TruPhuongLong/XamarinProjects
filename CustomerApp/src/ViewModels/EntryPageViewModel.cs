using System;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using Xamarin.Forms;

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
			await NavService.NavigateToViewModel<CustomerListPageViewModel>();
		}
        
        //COMMAND /push CustomerLoginPage
		Command pushCustomerLoginPage;
		public Command PushCustomerLoginPage
        {
			get => pushCustomerLoginPage ?? (pushCustomerLoginPage = new Command(ExecuteCommand_PushCustomerLoginPage));
        }
		async void ExecuteCommand_PushCustomerLoginPage()
        {
            await NavService.NavigateToViewModel<CustomerLoginPageViewModel>();
        }

	}
}
