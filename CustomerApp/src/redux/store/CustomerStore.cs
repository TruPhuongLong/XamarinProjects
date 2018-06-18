using System;
using CustomerApp.src.Models;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.reducers;
using CustomerApp.src.ViewModels;

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

		// constructor:
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
