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
		}


        public override Task Init()
        {
            throw new NotImplementedException();
        }


        

		Command pushToFinishPageCommand;
		public Command PushToFinishPageCommand
        {
			get => pushToFinishPageCommand ?? (pushToFinishPageCommand = new Command(Execute_PushToFinishPageCommand));
        }
		async void Execute_PushToFinishPageCommand()
        {
			await NavService.NavigateToViewModel<CustomerFinishPageViewModel>();
        }



	}
}
