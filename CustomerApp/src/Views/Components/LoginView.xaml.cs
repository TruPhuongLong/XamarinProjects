using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using CustomerApp.src.Models;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
	public partial class LoginView : ContentView
    {

        public LoginView()
        {
            InitializeComponent();
			BindingContext = new LoginView_ViewModel();

			ViewModel.LoginEventHandler += _LoginEventHandler;
        }

        //VIEWMODEL
		LoginView_ViewModel ViewModel
		{
			get => BindingContext as LoginView_ViewModel;
		}
        

		void _LoginEventHandler(object sender, User user)
		{
			if (LoginEventHandler != null) LoginEventHandler(this, user);
		}

		//EVENT
        public event EventHandler<User> LoginEventHandler;

    }
}
