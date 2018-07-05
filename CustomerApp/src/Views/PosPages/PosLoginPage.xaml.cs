using System;
using System.Diagnostics;
using CustomerApp.src.Models;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.ViewModels;
using CustomerApp.src.Views.Components;
using Xamarin.Forms;

namespace CustomerApp.src.Views.PosPages
{
	public partial class PosLoginPage : ContentPage
    {
        public PosLoginPage()
        {
            InitializeComponent();
			BindingContext = new PosLoginPageViewModel(DependencyService.Get<ICustomerNavService>(), DependencyService.Get<AuthService>());
        }

    }
}
