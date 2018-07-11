using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.store;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public class CustomerEditPageViewModel: BaseViewModel<Tuple<Customer, string>>
    {
		private CustomerService CustomerService;
		private SignalRService SignalRService;
		public CustomerEditPageViewModel(ICustomerNavService navService, CustomerService customerService, SignalRService signalRService): base(navService)
        {
			CustomerService = customerService;
			SignalRService = signalRService;
        }

		public override Task Init(Tuple<Customer , string> _tuple)
		{
			return Task.Run(() => {
				Tuple = _tuple;
			});
		}
        
		//PROP
		private Tuple<Customer, string> tuple;
		public Tuple<Customer, string> Tuple
        {
			get => tuple;
            set
            {
				SetProperty(ref tuple, value);
            }
        }

        //PROP
		private string currentPointsDelta = "3";
		public string CurrentPointsDelta
        {
			get => currentPointsDelta;
			set 
			{ 
				SetProperty(ref currentPointsDelta, value); 
			}
        }

		//COMMAND
		private Command saveCommand;
		public Command SaveCommand
		{
			get => saveCommand ?? (saveCommand = new Command(ExecuteCommand));
		}
		async void ExecuteCommand()
		{
			//validate CurrentPoints
			if(!ValidateCurrentPointsDelta())
			{
				// message currentPoint not float number:
                ((CustomerStore)CustomerStore).Dispath_Notification("wrong format");
				return;
			}

			// trigger up indicator
			((CustomerStore)CustomerStore).Dispath_Indicator(true);

			var _CurrentPointsDelta = float.Parse(CurrentPointsDelta);
			var newCustomer = Tuple.Item1;
			newCustomer.CurrentPoints = Tuple.Item2 == "+" ? Tuple.Item1.CurrentPoints + _CurrentPointsDelta : Tuple.Item1.CurrentPoints - _CurrentPointsDelta;
			var CustomerEdited = await CustomerService.Put(newCustomer);

			if(CustomerEdited != null)
			{
				await NavService.PreviousPage();
				await SignalRService.CustomerLeaveGroup(newCustomer.ID.ToString());
				((CustomerStore)CustomerStore).Dispath_Notification("save success");
			}
			else
			{
				// fail to save edit:
				((CustomerStore)CustomerStore).Dispath_Notification("save fail");
			}

			// trigger off indicator
			((CustomerStore)CustomerStore).Dispath_Indicator(false);
		}
		bool ValidateCurrentPointsDelta()
		{
			//if (CurrentPoints == null) return false;
			float n;
			return float.TryParse(CurrentPointsDelta, out n);
		}

	}
}
