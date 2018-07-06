using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using Xamarin.Forms;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using CustomerApp.src.redux.actions;

namespace CustomerApp.src.ViewModels
{
	public class PosLoginPageViewModel: BaseViewModel
    {
		AuthService AuthService;

		public PosLoginPageViewModel(ICustomerNavService navService, AuthService authService) : base(navService)
        {
			AuthService = authService;
        }

		public override Task Init()
		{
 			throw new NotImplementedException();
		}
                    

        
        //COMMAND /request login
		private Command<User> loginCommand;
		public Command<User> LoginCommand
		{
			get => loginCommand ?? (loginCommand = new Command<User>(ExecuteCommand));
		}
		async void ExecuteCommand(User user)
		{
			// trigger up indicator
			CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState(new Customer[] { }, true)));
            
			var result = await AuthService.Login(user);
            if (result)
            {
                // login success:
                await NavService.NavigateToViewModel<EntryPageViewModel>();            
            }
            else
            {
				//login fail:
			}

			// trigger off indicator
            CustomerStore.Dispath(new IndicatorAction(new redux.store.CustomerState(new Customer[] { }, false)));
		}
    }
}
