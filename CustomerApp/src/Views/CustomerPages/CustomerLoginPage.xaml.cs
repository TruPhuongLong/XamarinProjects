using System.Diagnostics;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.CustomerPages
{
    public partial class CustomerLoginPage : ContentPage
    {
        public CustomerLoginPage()
        {
            InitializeComponent();
			BindingContext = new CustomerLoginPageViewModel(DependencyService.Get<ICustomerNavService>(), DependencyService.Get<DataService>(), DependencyService.Get<SignalRService>());
        }
        
    }
}
