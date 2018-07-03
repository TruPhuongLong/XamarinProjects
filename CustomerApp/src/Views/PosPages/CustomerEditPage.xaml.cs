using System;
using System.Collections.Generic;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.PosPages
{
    public partial class CustomerEditPage : ContentPage
    {
        public CustomerEditPage()
        {
            InitializeComponent();
			BindingContext = new CustomerEditPageViewModel(DependencyService.Get<ICustomerNavService>());
        }
    }
}
