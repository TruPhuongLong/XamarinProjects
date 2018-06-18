using System;
using CustomerApp.src.Models;

namespace CustomerApp.src.redux.actions
{
	public class RemoveCustomerAction: IAction<Customer>
    {
		public _Type _Type { get => _Type.RemoveCustomer; }

		public Customer Payload { get; set; }

		public RemoveCustomerAction(Customer payload)
        {
			Payload = payload;
        }

        
	}
}
