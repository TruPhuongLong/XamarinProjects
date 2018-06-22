using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using Xamarin.Forms;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;

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

		//REQUEST /login
		public async void Login(User user)
		{
			var result = await AuthService.Login(user);
			if(result){
				// login success:
				await NavService.NavigateToViewModel<EntryPageViewModel>();

				// connect signalR:
				InitSignalR();
			}else{
				//login fail:
			}
		}

		private void InitSignalR()
        {
            DependencyService.Get<SignalRService>();
        }
    }
}
