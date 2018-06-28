using System;
using System.Collections.Generic;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class Field : ContentView
    {
        public Field()
        {
            InitializeComponent();
			BindingContext = new Field_ViewModel();
        }

		Field_ViewModel ViewModel
		{
			get => BindingContext as Field_ViewModel;
		}

        //Input
        //Input /placeholder
		public string Placeholder
		{
            set 
			{
				ViewModel.Placeholder = value;
			}
		}

        //Input /validate /require
		public bool Require
        {
            set
            {
				ViewModel.Require = value;
            }
        }

		//Input /validate /require
		public string Minlength
        {
            set
            {
				ViewModel.Minlength = value;
            }
        }

		//Input /validate /IsEmail
		public bool IsEmail
        {
            set
            {
				ViewModel.IsEmail = value;
            }
        }


    }
}
