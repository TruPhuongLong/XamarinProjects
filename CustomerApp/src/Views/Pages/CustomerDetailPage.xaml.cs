using System;
using System.Collections.Generic;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Pages
{
	public partial class CustomerDetailPage : ContentPage
    {
		// need constructor parameterLess for ViewModel init Page at first push.
		public CustomerDetailPage()
		{
		}
		public CustomerDetailPage(Customer customer)
        {
            InitializeComponent();
			BindingContext = new CustomerDetailPageViewModel(DependencyService.Get<ICustomerNavService>());
        }
    }
}
