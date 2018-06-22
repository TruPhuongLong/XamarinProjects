using System;
using System.Threading.Tasks;
using CustomerApp.src.ViewModels;

namespace CustomerApp.src.Services.NavigationService
{
	public interface ICustomerNavService
    {
		Task PreviousPage();
		Task BackToMainPage();
		Task NavigateToViewModel<ViewModel>() where ViewModel : BaseViewModel;
		Task NavigateToViewModel<ViewModel, TParameter>(TParameter parameter) where ViewModel : BaseViewModel<TParameter>;
    }
}
