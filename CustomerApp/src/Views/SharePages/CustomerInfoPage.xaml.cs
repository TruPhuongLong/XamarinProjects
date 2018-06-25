using System;
using System.Collections.Generic;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.SharePages
{
	public partial class CustomerInfoPage : ContentPage
    {
		public CustomerInfoPage()
        {
            InitializeComponent();
			BindingContext = new CustomerInfoPageViewModel(DependencyService.Get<ICustomerNavService>(), DependencyService.Get<SignalRService>());
        }
    }
}
