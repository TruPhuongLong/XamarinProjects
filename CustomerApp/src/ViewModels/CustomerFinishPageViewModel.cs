using System;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using Xamarin.Forms;
using CustomerApp.src.libs;
using CustomerApp.src.Views.CustomerPages;
using CustomerApp.src.Services.signalRService;
using CustomerApp.src.Views.PosPages;

namespace CustomerApp.src.ViewModels
{
	public class CustomerFinishPageViewModel: BaseViewModel
    {
		private SignalRService2 SignalRService;
		public CustomerFinishPageViewModel(ICustomerNavService navService, SignalRService2 signalRService): base(navService)
        {
			SignalRService = signalRService;
        }

		public override async Task Init()
		{
			await Task.Delay(1);
            //auto back page 
			Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                if (FuncHelp.CurrentPage() is CustomerFinishPage)
                {
					ExitCommand.Execute(null); 
                }
                return false; // not repeat
            });
		}

        //COMMAND /exit
		Command exitCommand;
        public Command ExitCommand
        {
            get => exitCommand ?? (exitCommand = new Command(ExecuteCommand));
        }
        async void ExecuteCommand()
        {
            //leave SignalR
			await SignalRService.CustomersChanged("");

            //back page
			if (FuncHelp.GetRootPage() is PosLoginPage)
            {
				await NavService.PreviousPage();
				await NavService.PreviousPage();
            }
			else
			{
				await NavService.BackToMainPage();
			}

        }
	}
}
