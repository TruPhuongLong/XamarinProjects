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
		//public async void Login(User user)
		//{
		//	var result = await AuthService.Login(user);
		//	if(result){
		//		// login success:
		//		await NavService.NavigateToViewModel<EntryPageViewModel>();

		//		// connect signalR:
		//		InitSignalR();
		//	}else{
		//		//login fail:
		//	}
		//}
        
		////COMMAND /Login Command:
   //     Command<User> loginCommand;
   //     public Command<User> LoginCommand
   //     {
			//get => loginCommand ?? (loginCommand = new Command<User>(user => ExecuteCommand(user)));
   //     }
   //     async void ExecuteCommand(User user)
   //     {
			//var result = await AuthService.Login(user);
        //    if (result)
        //    {
        //        // login success:
        //        await NavService.NavigateToViewModel<EntryPageViewModel>();

        //        // connect signalR:
        //        InitSignalR();
        //    }
        //    else
        //    {
        //        //login fail:
        //    }
        //}


		//COMMAND /Login Command:
        Command loginCommand;
        public Command ALoginCommand
        {
			get => loginCommand ?? (loginCommand = new Command(ExecuteCommand));
        }
        async void ExecuteCommand()
        {
            
        }



		private void InitSignalR()
        {
            DependencyService.Get<SignalRService>();
        }
    }
}
