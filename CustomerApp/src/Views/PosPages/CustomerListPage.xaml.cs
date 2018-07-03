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
        CustomerListPageViewModel ViewModel
        {
            get => BindingContext as CustomerListPageViewModel;
        }

        public CustomerListPage()
        {
            InitializeComponent();
			BindingContext = new CustomerListPageViewModel(DependencyService.Get<ICustomerNavService>(), DependencyService.Get<SignalRService>());
			Title = "Check In List";
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Customer? customer = (Customer)e.Item;
            if (customer == null) return;
            ViewModel.DetailCommand.Execute(customer);
        }

		void Handle_GiftEventHandler(object sender, Customer customer)
        {
			ViewModel.GiftCommand.Execute(customer);
        }
    }
}
