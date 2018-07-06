using System;
using CustomerApp.src.Models;
using CustomerApp.src.redux.store;

namespace CustomerApp.src.redux.actions
{
	public class ListCustomerChangedAction: IAction
    {
		public _Type _Type { get => _Type.ListCustomerChanged; }
		public CustomerState Payload { get; set; }

		public ListCustomerChangedAction(CustomerState payload)
        {
			Payload = payload;
        }
    }
}
