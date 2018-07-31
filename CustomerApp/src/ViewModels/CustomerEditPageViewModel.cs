using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.libs;
using CustomerApp.src.Models;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.store;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public class CustomerEditPageViewModel: BaseViewModel<string>
    {
		private CustomerService CustomerService;
		private SignalRService2 SignalRService;
		public CustomerEditPageViewModel(ICustomerNavService navService, CustomerService customerService, SignalRService2 signalRService): base(navService)
        {
			CustomerService = customerService;
			SignalRService = signalRService;
        }

		public override Task Init(string styleid)
		{
			return Task.Run(() => {
				Styleid = styleid;
			});
		}

		//PROP /need for binding
		private string styleid;
		public string Styleid 
		{
			get => styleid;
			set
			{
				SetProperty(ref styleid, value);	
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
			var newCustomer = (Customer)CustomerStore.State.Customer;
			newCustomer.CurrentPoints = Styleid == "+" ? newCustomer.CurrentPoints + _CurrentPointsDelta : newCustomer.CurrentPoints - _CurrentPointsDelta;

			//filter currentpoint:
			if (newCustomer.CurrentPoints < 0) newCustomer.CurrentPoints = 0;

            //update customer
			var CustomerEdited = await CustomerService.Put(newCustomer);

			if(CustomerEdited != null)
			{
				((CustomerStore)CustomerStore).Dispath_Notification("save success");
				await SignalRService.CustomersChanged(CustomerEdited);

                //back page
				await NavService.PreviousPage();
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
