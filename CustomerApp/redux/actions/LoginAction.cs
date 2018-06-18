using System;
using CustomerApp.src.Models;

namespace CustomerApp.redux.actions
{
	public class LoginAction : _Action
	{
		public _Type _Type { get => _Type.Login; }
		public Object Payload { get; set; }

		public LoginAction(Object payload)
		{
			Payload = payload;
		}
	}
}
