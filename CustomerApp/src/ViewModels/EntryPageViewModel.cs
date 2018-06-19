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
		protected EntryPageViewModel(ICustomerNavService navService) : base(navService)
		{
		}

		public override Task Init()
		{
			throw new NotImplementedException();
		}


		//=============================Business for CustomerEntryPage:=============================
		// login command:
		Command loginCommand;
		public Command LoginCommand
		{
			get => loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand(), ValidateFormLogin));
		}

		async Task ExecuteLoginCommand()
		{
			var loginCustomer = await Task.Run<Customer>(() =>
                 // request service login:                              
                 new Customer { Name = "", Message = "" }
			);
			if (loginCustomer != null)
			{
				await NavService.NavigateToViewModel<CustomerInfoPageViewModel, Customer>(loginCustomer);
			}
			else
			{
				await NavService.NavigateToViewModel<CustomerSignupPageViewModel, Customer>(null);
			}
		}

		bool ValidateFormLogin()
		{
			return true;
		}
	}
}
