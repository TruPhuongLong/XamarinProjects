using System;
using CustomerApp.src.Models;

namespace CustomerApp.src.redux.actions
{
	public class AddCustomerAction : IAction<Customer>
	{
		public _Type _Type { get => _Type.AddCustomer; }
		public Customer Payload { get; set; }

		public AddCustomerAction(Customer payload)
		{
			Payload = payload;
		}
	}
}
