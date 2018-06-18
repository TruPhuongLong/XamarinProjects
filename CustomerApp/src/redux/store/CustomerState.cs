using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CustomerApp.src.Models;

namespace CustomerApp.src.redux.store
{
	public struct CustomerState
    {
		Customer Customer { get; set; }
		Customer[] CustomerHistory { get; set; }
	}
}