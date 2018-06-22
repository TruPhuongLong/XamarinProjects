using System;
using System.Collections.Generic;
using System.Diagnostics;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.PosPages
{
    public partial class CustomerListPage : ContentPage
    {
        CustomerListPageViewModel viewModel
        {
            get => BindingContext as CustomerListPageViewModel;
        }

        public CustomerListPage()
        {
            InitializeComponent();
			BindingContext = new CustomerListPageViewModel(DependencyService.Get<ICustomerNavService>(), DependencyService.Get<SignalRService>());

        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Customer? customer = (Customer)e.Item;
            if (customer == null) return;
            viewModel.DetailCommand.Execute(customer);
        }
    }
}
