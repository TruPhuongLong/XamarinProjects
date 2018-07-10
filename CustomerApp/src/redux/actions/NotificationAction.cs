using System;
using CustomerApp.src.redux.store;

namespace CustomerApp.src.redux.actions
{
	public class NotificationAction: IAction
    {
		public _Type _Type { get => _Type.Notification; }

		public CustomerState Payload { get; set; }

		public NotificationAction(CustomerState payload)
        {
			Payload = payload;
        }

	}
}
