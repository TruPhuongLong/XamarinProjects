using System;
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
			Button btn = (Button)sender;

			if (GiftEventHandler != null)
            {
				GiftEventHandler(this, new Tuple<Customer, string>((Customer)ViewModel, btn.StyleId));
            }

		}

		//EVENT
		public event EventHandler<Tuple<Customer, string>> GiftEventHandler;
        

    }
}
