using System;
using CustomerApp.src.Models;

namespace CustomerApp.src.redux.actions
{
	public class ListCustomerChangedAction: IAction<Customer[]>
    {
		public _Type _Type { get => _Type.ListCustomerChanged; }
        public Customer[] Payload { get; set; }

		public ListCustomerChangedAction(Customer[] payload)
        {
			Payload = payload;
        }
    }
}
