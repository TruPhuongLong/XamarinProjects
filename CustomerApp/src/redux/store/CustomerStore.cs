using System;
using System.Collections.ObjectModel;
using CustomerApp.src.Models;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.reducers;
using CustomerApp.src.redux.store;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerStore))]
namespace CustomerApp.src.redux.store
{
	public class CustomerStore : CoreBaseViewModel, IStore<CustomerState, Customer>
	{
		// state:
		private CustomerState state;
		public CustomerState State
		{
			get => state;
			private set { SetProperty(ref state, value); }
		}

		// reducer:
		private IReducer<CustomerState, Customer> reducer;      
		public IReducer<CustomerState, Customer> Reducer 
		{
			get => reducer;
			private set { reducer = value; }
		}

		// main init:
		public CustomerStore()
		{
			var CustomerReducer = DependencyService.Get<IReducer<CustomerState, Customer>>() as CustomerReducer;
			var CustomerState = new CustomerState(){ CustomerHistory = new ObservableCollection<Customer>()};
			Constructor(CustomerReducer, CustomerState);
		}


		// constructor implement IStore:
		public void Constructor(IReducer<CustomerState, Customer> reducer, CustomerState initialState)
		{
			State = initialState;
			Reducer = reducer;
		}

		// dispatch:
		public void Dispath(IAction<Customer> action)
		{
			State = Reducer.Exec(State, action);
		}
        
	}
}
