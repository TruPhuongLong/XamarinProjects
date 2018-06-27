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
			//BindingContext = new LoginView_ViewModel();

			//ViewModel.LoginEventHandler += _LoginEventHandler;
        }

        //VIEWMODEL
		//LoginView_ViewModel ViewModel
		//{
		//	get => BindingContext as LoginView_ViewModel;
		//}
        

		//void _LoginEventHandler(object sender, User user)
		//{
		//	Execute(LoginCommand);
		//}

		void OnLoginClicked(object sender, EventArgs args)
		{
			Execute(LoginCommand);
		}

		public static readonly BindableProperty LoginCommandProperty = BindableProperty.Create(nameof(LoginCommand), typeof(ICommand), typeof(LoginView), null);

        public ICommand LoginCommand
        {
			get { return (ICommand)GetValue(LoginCommandProperty); }
			set { SetValue(LoginCommandProperty, value); }
        }

        // Helper method for invoking commands savely
        public void Execute(ICommand command)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
                command.Execute(null);
            }
        }
    }
}
