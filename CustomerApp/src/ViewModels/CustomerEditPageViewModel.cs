using System;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;

namespace CustomerApp.src.ViewModels
{
	public class CustomerEditPageViewModel: BaseViewModel<Customer>
    {
		public CustomerEditPageViewModel(ICustomerNavService navService): base(navService)
        {
        }

		public override Task Init(Customer parameter)
		{
			return Task.Run(() => Customer = parameter);
		}

		private Customer customer;
		public Customer Customer
		{
			get => customer;
			set { SetProperty(ref customer, value); }
		}
	}
}
