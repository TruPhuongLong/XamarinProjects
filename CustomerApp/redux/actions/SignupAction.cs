using System;
using CustomerApp.src.Models;

namespace CustomerApp.redux.actions
{
	public class SignupAction: _Action
    {
		public _Type _Type { get => _Type.Signup; }

		public Object Payload { get; set; }

		public SignupAction(Object payload)
        {
			Payload = payload;
        }


	}
}
