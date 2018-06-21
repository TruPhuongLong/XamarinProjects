using System;
using System.Diagnostics;
using CustomerApp.src.Models;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.PosPages
{
    public partial class PosLoginPage : ContentPage
    {
        public PosLoginPage()
        {
            InitializeComponent();
			BindingContext = new PosLoginPageViewModel();
        }

		void LoginEventHandler(object sender, User user)
		{
		}
        
    }
}
