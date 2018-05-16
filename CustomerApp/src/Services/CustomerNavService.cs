using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CustomerApp.src.Services;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

//[assembly: Dependency(typeof(CustomerNavService))]
namespace CustomerApp.src.Services
{
	public class CustomerNavService: ICustomerService
    {
		public INavigation navigation { get; set; }
		readonly IDictionary<Type, Type> viewMapping = new Dictionary<Type, Type>();

		public Task BackToMainPage()
		{
			throw new NotImplementedException();
		}

		public Task NavigateToViewModel<ViewModel, TParameter>(TParameter parameter) where ViewModel : BaseViewModel
		{
			throw new NotImplementedException();
		}

		public Task PreviousPage()
		{
			throw new NotImplementedException();
		}
	}
}
