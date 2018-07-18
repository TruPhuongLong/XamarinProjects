using System;
using System.Collections.Generic;
using System.Diagnostics;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;
using CustomerApp.src.Views.Components;

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
			Title = "Check In List";
        }

      
              
		void OnChangeRewardPoint(object sender, EventArgs args)
        {
			Button btn = (Button)sender;
			if(btn.StyleId == "0")
			{
				ViewModel.NoChangePointCommand.Execute(null);
			}
			else
			{
				ViewModel.ChangePointCommand.Execute(btn.StyleId);
			}
        }


        // don't know why it need some second delay.
		//if i put this statement on public CustomerListPage(). then it can not run signalR join to server.
		protected override void OnAppearing()
		{
			base.OnAppearing();
			BindingContext = new CustomerListPageViewModel(DependencyService.Get<ICustomerNavService>(), DependencyService.Get<SignalRService2>());
		}

		//FUNC /remove view if Delta birthday < 10
		private void OnBirthdayBCTC(object sender, EventArgs args)
		{
			CustomerBirthdayMessageView cbmv = (CustomerBirthdayMessageView)sender;
			if (cbmv == null) return;

			var customer = cbmv.BindingContext as Customer?;
			if (customer == null) return;

			//good to go
			//check delta birthday
			var customerDayOfBirth = ((Customer)customer).DateOfBirth;
			var timeForCal = new DateTime(customerDayOfBirth.Year, DateTime.Now.Month, DateTime.Now.Day);

			var delta = (timeForCal - customerDayOfBirth).Days;

			//check delta in range 0-10:
			if(delta > 10 || delta < 0)
			{            
                //remove CustomerBirthdayMessageView
                var parent = cbmv.Parent as Grid;
				if (parent == null) return;
                parent.Children.Remove(cbmv);

                
			}else{
				cbmv.IsVisible = true;
			}

		}
	}
}
