using System;
using System.Collections.Generic;
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
			BindingContext = new CustomerSignupPageViewModel(DependencyService.Get<ICustomerNavService>());
			Title = "Customer Signup";
        }
    }
}
