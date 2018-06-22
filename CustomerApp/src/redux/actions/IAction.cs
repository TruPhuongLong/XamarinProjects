using System;
namespace CustomerApp.src.redux.actions
{
	public interface IAction<T>
    {
		_Type _Type { get;}
		T Payload  { get;}
    }

	public enum _Type
	{
		AddCustomer,
        RemoveCustomer,
        UpdateCustomer,
        ListCustomerChanged,
	}
}
