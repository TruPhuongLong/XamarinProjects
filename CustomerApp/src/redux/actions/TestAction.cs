using System;
using CustomerApp.src.Models;

namespace CustomerApp.src.redux.actions
{
	public class TestAction : IAction<Customer>
	{
		public _Type _Type { get => _Type.TestAddCustomer; }
		public Customer Payload { get; set; }

		public TestAction(Customer payload)
        {
            Payload = payload;
        }
	}
}
