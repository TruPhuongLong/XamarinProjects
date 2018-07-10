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
	
	public class CustomerReducer: IReducer<CustomerState>
	{
		public CustomerState Exec(CustomerState state, IAction action)
        {
            switch (action._Type)
            {
				case _Type.ListCustomerChanged:
					var newState_ListCustomerChanged = ListCustomerChanged(state, action);
					return newState_ListCustomerChanged;
				case _Type.Indicator:
					var newState_Indicator = Indicator(state, action);
					return newState_Indicator;
				case _Type.Notification:
					var newState_Notification = Notification(state, action);
					return newState_Notification;
                default:
                    return state;
            }
        }
        

		//FUNC /ListCustomerChanged
		private CustomerState ListCustomerChanged(CustomerState state, IAction action)
		{
			//var newState = new CustomerState();
			// because state is not reference, it is copy, so not need copy again.
			state.CustomerHistory = action.Payload.CustomerHistory;
			return state;
		}

		//FUNC /Indicator
		private CustomerState Indicator(CustomerState state, IAction action)
        {
			state.IsRunningIndicator = action.Payload.IsRunningIndicator;
            return state;
        }
      
		//FUNC /Notification
		private CustomerState Notification(CustomerState state, IAction action)
        {
			state.Notification = action.Payload.Notification;
            return state;
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
