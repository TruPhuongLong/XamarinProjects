using System;
using CustomerApp.src.redux.store;

namespace CustomerApp.src.redux.actions
{
	public class CustomerChangedAction: IAction
    {
		public _Type _Type { get => _Type.CustomerChanged; }
        public CustomerState Payload { get; set; }

		public CustomerChangedAction(CustomerState payload)
        {
            Payload = payload;
        }
    }
}
