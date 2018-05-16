﻿using System;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;

namespace CustomerApp.src.ViewModels
{
	public class CustomerDetailPageViewModel : BaseViewModel<Customer>
	{
		// Implement BaseViewModel<Customer>
		public CustomerDetailPageViewModel(ICustomerNavService navService) : base(navService)
		{
		}

		public override async Task Init(Customer customerInput)
		{
			await Task.Run(() =>
			    Customer = customerInput
		    );
		}


		// Business for CustomerDetailPage:
		Customer customer;
		public Customer Customer
		{
			get => customer;
			set
			{
				SetProperty(ref customer, value);
			}
		}
	}
}
