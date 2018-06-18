using System;
using CustomerApp.src.Models;

namespace CustomerApp.src.redux.actions
{
	public class UpdateCustomerAction : IAction<Customer>
	{
		public _Type _Type { get => _Type.UpdateCustomer; }
		public Customer Payload { get; set; }

		public UpdateCustomerAction(Customer payload)
        {
            Payload = payload;
        }
	}
}
