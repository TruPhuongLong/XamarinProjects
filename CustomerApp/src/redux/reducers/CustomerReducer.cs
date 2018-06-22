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
	public class CustomerReducer : IReducer<CustomerState, Customer[]>
	{
		public CustomerState Exec(CustomerState state, IAction<Customer[]> action)
        {
            switch (action._Type)
            {
				case _Type.ListCustomerChanged:
					var newState_ListCustomerChanged = ListCustomerChanged(state, action);
					return newState_ListCustomerChanged;
                default:
                    return state;
            }
        }

		public CustomerState ListCustomerChanged(CustomerState state, IAction<Customer[]> action)
		{
			var newState = new CustomerState();
			newState.CustomerHistory = action.Payload;
			return newState;
		}




		// Only good but not need for now:


		//public CustomerState Exec(CustomerState state, IAction<Customer> action)
		//{
		//	switch (action._Type)
		//	{
		//		case _Type.AddCustomer:
		//			var newState_Add = AddCustomer(state, action);
		//			return newState_Add;
		//		case _Type.RemoveCustomer:
		//			var newState_Remove = RemoveCustomer(state, action);
		//			return newState_Remove;
		//		case _Type.UpdateCustomer:
		//			var newState_Update = UpdateCustomer(state, action);
		//			return newState_Update;
		//		default:
		//			return state;
		//	}
		//}

		//private CustomerState AddCustomer(CustomerState state, IAction<Customer> action)
		//{
		//	var newState = new CustomerState();
		//	var length = state.CustomerHistory.Length;
		//	newState.CustomerHistory = new Customer[length + 1];
		//	state.CustomerHistory.CopyTo(newState.CustomerHistory, 0);
		//	newState.CustomerHistory[length] = action.Payload;
		//	return newState;
		//}

		//private CustomerState RemoveCustomer(CustomerState state, IAction<Customer> action)
		//{
		//	var newState = new CustomerState();         
		//	var list = new List<Customer>();
		//	Array.ForEach(state.CustomerHistory, customer =>
		//	{
		//		if(customer.Id != action.Payload.Id)
		//		{
		//			list.Add(customer);
		//		}
		//	});

		//	// set array customer:
		//	newState.CustomerHistory = list.ToArray();
		//	return newState;
		//}

		//private CustomerState UpdateCustomer(CustomerState state, IAction<Customer> action)
   //     {
			//var newState = new CustomerState();         
    //        var list = new List<Customer>();
    //        Array.ForEach(state.CustomerHistory, customer =>
    //        {
    //            if (customer.Id == action.Payload.Id)
    //            {
				//	customer = action.Payload;
    //            }
				//list.Add(customer);
        //    });

        //    // set array customer:
        //    newState.CustomerHistory = list.ToArray();
        //    return newState;
        //}
	}
}
