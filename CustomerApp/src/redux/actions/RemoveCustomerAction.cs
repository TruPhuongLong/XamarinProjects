using System;
using CustomerApp.src.Models;
using CustomerApp.src.redux.store;

namespace CustomerApp.src.redux.actions
{
	public class RemoveCustomerAction: IAction
    {
		public _Type _Type { get => _Type.RemoveCustomer; }

		public CustomerState Payload { get; set; }

		public RemoveCustomerAction(CustomerState payload)
        {
			Payload = payload;
        }

        
	}
}
