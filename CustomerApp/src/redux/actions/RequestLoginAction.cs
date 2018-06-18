using System;
using CustomerApp.src.Models;

namespace CustomerApp.src.redux.actions
{
	public class RequestLoginAction : IAction<Customer>
	{
		public _Type _Type { get => _Type.RequestLogin; }
		public Customer Payload { get; set; }

		public RequestLoginAction(Customer payload)
		{
			Payload = payload;
		}
	}
}
