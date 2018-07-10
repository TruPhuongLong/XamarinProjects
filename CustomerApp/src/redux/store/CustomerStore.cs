using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.reducers;
using CustomerApp.src.redux.store;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerStore))]
namespace CustomerApp.src.redux.store
{
	public class CustomerStore : CoreBaseViewModel, IStore<CustomerState>
	{      
		// state:
        private CustomerState state;
        public CustomerState State
        {
          get => state;
          private set { SetProperty(ref state, value); }
        }

		// reducer:
		private IReducer<CustomerState> reducer;      
		public IReducer<CustomerState> Reducer 
        {
          get => reducer;
          private set { reducer = value; }
        }

		// main init:
        public CustomerStore()
        {
			var CustomerReducer = DependencyService.Get<IReducer<CustomerState>>() as CustomerReducer;
			var CustomerState = new CustomerState() { CustomerHistory = new Customer[] { } };
			Constructor(CustomerReducer, CustomerState);
        }

		// constructor implement IStore:
		public void Constructor(IReducer<CustomerState> reducer, CustomerState initialState)
		{
			State = initialState;
            Reducer = reducer;
		}

		// dispatch:
		public void Dispath(IAction action)
		{
			State = Reducer.Exec(State, action);
		}

		public async void Dispath_Notification(string mes)
		{
			Dispath(new NotificationAction(new CustomerState(notification: new Notification(trigger: false, message: mes))));
			await Task.Delay(300);
			Dispath(new NotificationAction(new CustomerState(notification: new Notification( trigger: true, message: mes))));
		}

		public void Dispath_Indicator(bool isRunningIndicator)
		{
			Dispath(new IndicatorAction(new CustomerState(isRunningIndicator: isRunningIndicator)));
		}
	}
}
