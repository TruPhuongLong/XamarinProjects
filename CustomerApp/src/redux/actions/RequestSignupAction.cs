using System;
using CustomerApp.src.Models;

namespace CustomerApp.src.redux.actions
{
	public class RequestSignupAction: IAction<Customer>
    {
		public _Type _Type { get => _Type.RequestSignup; }

		public Customer Payload { get; set; }

		public RequestSignupAction(Customer payload)
        {
			Payload = payload;
        }

        
	}
}
