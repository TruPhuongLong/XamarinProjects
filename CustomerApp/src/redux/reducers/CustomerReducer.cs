using System;
using System.Collections.ObjectModel;
using CustomerApp.src.Models;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.reducers;
using CustomerApp.src.redux.store;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerReducer))]
namespace CustomerApp.src.redux.reducers
{
	public class CustomerReducer : IReducer<CustomerState, Customer>
	{

		public CustomerState Exec(CustomerState state, IAction<Customer> action)
		{
			switch (action._Type)
			{
				case _Type.TestAddCustomer:
					var newState = TestAddCustomer(state, action);
						return newState;
				case _Type.RequestLogin:
					return state;
				case _Type.ResponseLogin:
                    return state;
				case _Type.RequestSignup:
					return state;
				case _Type.ResponseSignup:
                    return state;
				default:
					return state;
			}
		}

		private CustomerState TestAddCustomer(CustomerState state, IAction<Customer> action)
		{
			var newState = new CustomerState();
			// get Customer:
			newState.Customer = action.Payload;

			// get Array CustomerHistory:
			newState.CustomerHistory = new ObservableCollection<Customer>(state.CustomerHistory);
			newState.CustomerHistory.Add(action.Payload);

			return newState;
		}


	}
}
