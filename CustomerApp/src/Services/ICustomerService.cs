using System;
using System.Threading.Tasks;
using CustomerApp.src.ViewModels;

namespace CustomerApp.src.Services
{
    public interface ICustomerService
    {
		Task PreviousPage();
		Task BackToMainPage();
		Task NavigateToViewModel<ViewModel, TParameter>(TParameter parameter) where ViewModel : BaseViewModel;
    }
}
