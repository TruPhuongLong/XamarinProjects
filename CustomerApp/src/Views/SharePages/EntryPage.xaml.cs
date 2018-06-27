﻿using System;
using System.Collections.Generic;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.SharePages
{
    public partial class EntryPage : ContentPage
    {
        public EntryPage()
        {
            InitializeComponent();
			BindingContext = new EntryPageViewModel(DependencyService.Get<ICustomerNavService>());
        }
    }
}