using System;
using System.Collections.ObjectModel;
using CustomerApp.src.Models;

namespace CustomerApp.src.ViewModels
{
	public class CustomerListPageViewModel: BaseViewModel
    {
		ObservableCollection<Customer> customerLists;
		public ObservableCollection<Customer> CustomerLists
		{
			get => customerLists;
            set
			{
				SetProperty(ref customerLists, value);
			}
		}

		public CustomerListPageViewModel()
		{
			CustomerLists = new ObservableCollection<Customer>()
			{
				new Customer{Name = "name1", Age = 20},
				new Customer{Name = "name2", Age = 30},
				new Customer{Name = "name3", Age = 40},
				new Customer{Name = "name4", Age = 25},
				new Customer{Name = "name5", Age = 60},
				new Customer{Name = "name6", Age = 23},
				new Customer{Name = "name7", Age = 29}
			};
		}
    }
}
