using System;
using CustomerApp.src.Models;
using CustomerApp.src.redux.store;

namespace CustomerApp.src.redux.actions
{
	public class UpdateCustomerAction : IAction
	{
		public _Type _Type { get => _Type.UpdateCustomer; }
		public CustomerState Payload { get; set; }

		public UpdateCustomerAction(CustomerState payload)
        {
            Payload = payload;
        }
	}
}
