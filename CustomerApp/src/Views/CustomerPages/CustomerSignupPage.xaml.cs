using System;
using System.Collections.Generic;
using System.Diagnostics;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.CustomerPages
{
    public partial class CustomerSignupPage : ContentPage
    {
        public CustomerSignupPage()
        {
            InitializeComponent();
			BindingContext = new CustomerSignupPageViewModel(DependencyService.Get<ICustomerNavService>(), DependencyService.Get<CustomerService>());
			Title = "Customer Signup";
        }

    }
}
