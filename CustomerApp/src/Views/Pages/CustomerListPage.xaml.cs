using System;
using System.Collections.Generic;
using System.Diagnostics;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Pages
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
			BindingContext = new CustomerListPageViewModel(DependencyService.Get<ICustomerNavService>());
		}
        
		protected async override void OnAppearing()
		{
			base.OnAppearing();
			if (viewModel == null)
			{
				Debug.WriteLine("CustomerListPage viewmodel == null");
			}
			else
			{
				Debug.WriteLine("CustomerListPage viewmodel != null");
				await viewModel.Init();
				     
			}
		}

		void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var customer = (Customer)e.Item;
			// don't understand why check customer:
			if (customer == null) return;
			viewModel.DetailCommand.Execute(customer);
			//customer = null;
		}
	}
}
