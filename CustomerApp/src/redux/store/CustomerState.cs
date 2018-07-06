using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CustomerApp.src.Models;

namespace CustomerApp.src.redux.store
{
	public struct CustomerState
	{
		//public Customer? Customer { get; set; }
		public Customer[] CustomerHistory { get; set; }
		public bool IsRunningIndicator { get; set; }

		//public CustomerState(){}

		public CustomerState(Customer[] customerHistory , bool isRunningIndicator)
		{
			CustomerHistory = customerHistory;
			IsRunningIndicator = isRunningIndicator;
		}
	}
}