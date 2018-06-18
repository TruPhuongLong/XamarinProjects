using System;
using System.Collections.Generic;
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
				case _Type.AddCustomer:
					var newState = AddCustomer(state, action);
						return newState;
				case _Type.RemoveCustomer:
					return state;
				case _Type.UpdateCustomer:
                    return state;
				default:
					return state;
			}
		}

		private CustomerState AddCustomer(CustomerState state, IAction<Customer> action)
		{
			var newState = new CustomerState();
			// set Customer:
			newState.Customer = action.Payload;
			// get CustomerHistory: use simple array:
			var length = state.CustomerHistory.Length;
			newState.CustomerHistory = new Customer[length + 1];
			state.CustomerHistory.CopyTo(newState.CustomerHistory, 0);
			newState.CustomerHistory[length] = action.Payload;

			return newState;
		}

		private CustomerState RemoveCustomer(CustomerState state, IAction<Customer> action)
		{
			var newState = new CustomerState();
			// set current customer:
			newState.Customer = null;

			var list = new List<Customer>();
			Array.ForEach(state.CustomerHistory, customer =>
			{
				if(customer.Id != action.Payload.Id)
				{
					list.Add(customer);
				}
			});

			// set array customer:
			newState.CustomerHistory = list.ToArray();
			return newState;
		}

		private CustomerState UpdateCustomer(CustomerState state, IAction<Customer> action)
        {
			var newState = new CustomerState();
            // set current customer:
			newState.Customer = action.Payload;

            var list = new List<Customer>();
            Array.ForEach(state.CustomerHistory, customer =>
            {
                if (customer.Id == action.Payload.Id)
                {
					customer = action.Payload;
                }
				list.Add(customer);
            });

            // set array customer:
            newState.CustomerHistory = list.ToArray();
            return newState;
        }
	}
}
