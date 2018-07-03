﻿using System;
using System.Collections.Generic;
using CustomerApp.src.Models;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
	public partial class CustomerCellView : ViewCell
    {
        public CustomerCellView()
        {
            InitializeComponent();
        }

		Customer? ViewModel
		{
			get => BindingContext as Customer?;
		}

		void OnGiftClicked(object sender, EventArgs args)
		{
			if (GiftEventHandler != null) 
				GiftEventHandler(this, (Customer)ViewModel);
		}

		//EVENT
		public event EventHandler<Customer> GiftEventHandler;

    }
}
