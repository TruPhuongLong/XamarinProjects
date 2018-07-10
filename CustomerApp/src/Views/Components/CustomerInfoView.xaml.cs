using System;
using System.Collections.Generic;
using System.Diagnostics;
using CustomerApp.src.libs;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class CustomerInfoView : ContentView
    {
        public CustomerInfoView()
        {
            InitializeComponent();
			if(LocalStorage.GetEnviroment() == Constants.POS_ENV)
			{
				layoutForPos.IsVisible = true;
				layoutForCustomer.IsVisible = false;
			}
			else
			{
				layoutForPos.IsVisible = false;
				layoutForCustomer.IsVisible = true;
			}
        }

    }
}
