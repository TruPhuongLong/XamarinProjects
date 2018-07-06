using System;
using CustomerApp.src.Models;
using CustomerApp.src.redux.store;

namespace CustomerApp.src.redux.actions
{
	public class AddCustomerAction : IAction
	{
		public _Type _Type { get => _Type.AddCustomer; }
		public CustomerState Payload { get; set; }
        
		public AddCustomerAction(CustomerState payload)
		{
			Payload = payload;
		}
	}
}
