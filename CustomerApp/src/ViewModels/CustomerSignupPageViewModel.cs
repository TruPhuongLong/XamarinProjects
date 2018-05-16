using System;
using System.Threading.Tasks;
using CustomerApp.src.Services;

namespace CustomerApp.src.ViewModels
{
	public class CustomerSignupPageViewModel : BaseViewModel
	{
		// Implement BaseViewModel:
		protected CustomerSignupPageViewModel(ICustomerNavService navService) : base(navService)
		{
		}

		public override Task Init()
		{
			throw new NotImplementedException();
		}
	}
}
