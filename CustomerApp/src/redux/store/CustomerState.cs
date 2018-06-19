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
		//public ObservableCollection<Customer> CustomerHistory { get; set; }
		public Customer[] CustomerHistory { get; set; }
	}
}