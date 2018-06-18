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
		RequestLogin,
        ResponseLogin,
        RequestSignup,
        ResponseSignup,
        TestAddCustomer,
	}
}
