using System;
using System.Collections.Generic;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.CustomerPages
{
    public partial class CustomerFinishPage : ContentPage
    {
		public CustomerFinishPage()
        {
            InitializeComponent();
			BindingContext = new CustomerFinishPageViewModel(DependencyService.Get<ICustomerNavService>(), DependencyService.Get<SignalRService2>());
        }
    }
}
