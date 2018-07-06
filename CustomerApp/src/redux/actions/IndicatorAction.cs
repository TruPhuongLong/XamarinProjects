using System;
using CustomerApp.src.redux.store;

namespace CustomerApp.src.redux.actions
{
	public class IndicatorAction: IAction
    {
		public _Type _Type { get => _Type.Indicator; }
		public CustomerState Payload { get; set; }

		public IndicatorAction(CustomerState payload)
        {
			Payload = payload;
        }      
	}
}
