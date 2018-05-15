using System;
using System.Collections.Generic;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Pages
{
    public partial class CustomerListPage : ContentPage
    {
        public CustomerListPage()
        {
            InitializeComponent();
			BindingContext = new CustomerListPageViewModel();
        }
    }
}
