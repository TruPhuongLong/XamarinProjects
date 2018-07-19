using System;
using System.Threading.Tasks;
using CustomerApp.src.libs;
using CustomerApp.src.Models;
using CustomerApp.src.redux.store;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using CustomerApp.src.Views.SharePages;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public class CustomerInfoPageViewModel : BaseViewModel
	{
		SignalRService2 SignalRService;

		// Implement BaseViewModel
		public CustomerInfoPageViewModel(ICustomerNavService navService, SignalRService2 signalRService) : base(navService)
		{
			SignalRService = signalRService;
			InitSignalR();
		}


        public override Task Init()
        {
            throw new NotImplementedException();
        }

		//Init SignalR:
		private void InitSignalR()
		{
			SignalRService.OnNextStep(() =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					PushToFinishPageCommand.Execute(null);
				});
			});
		}
        

		Command pushToFinishPageCommand;
		public Command PushToFinishPageCommand
        {
			get => pushToFinishPageCommand ?? (pushToFinishPageCommand = new Command(Execute_PushToFinishPageCommand));
        }
		async void Execute_PushToFinishPageCommand()
        {
			if(FuncHelp.CurrentPage() is CustomerInfoPage)
			{
				await NavService.NavigateToViewModel<CustomerFinishPageViewModel>();
			}
        }



	}
}
