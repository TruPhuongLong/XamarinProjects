using System;
using CustomerApp.src.redux.store;

namespace CustomerApp.src.redux.actions
{
	public interface IAction
	{
		_Type _Type { get; }
		CustomerState Payload  { get;}
    }

	public enum _Type
	{
		AddCustomer,
        RemoveCustomer,
        UpdateCustomer,
        ListCustomerChanged,
        Indicator,
        Notification
	}
}
