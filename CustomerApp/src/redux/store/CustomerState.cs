using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CustomerApp.src.Models;

namespace CustomerApp.src.redux.store
{
	public struct CustomerState
	{
		public Customer? Customer { get; set; }
		public Customer[] CustomerHistory { get; set; }
		public bool IsRunningIndicator { get; set; }
		public Notification? Notification { get; set; }

		//public CustomerState(){}

		public CustomerState(Customer[] customerHistory = null, bool isRunningIndicator = false, Notification? notification = null)
		{
			CustomerHistory = customerHistory;
			IsRunningIndicator = isRunningIndicator;
			Notification = notification;
			Customer = null;
		}
	}

	public struct Notification
	{
		public bool Trigger { get; set; }
		public string Message { get; set; }

		public Notification(bool trigger = false, string message = "")
		{
			Trigger = trigger;
			Message = message;
		}
	}
}