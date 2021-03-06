﻿using System;
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
		//PROPS:
		public string UserName { get; set; }
        public string Password { get; set; }

        public LoginView()
        {
            InitializeComponent();
        }

        //EVENT
		void OnLoginClicked(object sender, EventArgs args)
		{
			Execute(Command, new User{UserName = UserName, Password = Password});
		}

        //BINDABLE /command
		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(Command<User>), typeof(LoginView), null);

        public Command<User> Command
        {
            get { return (Command<User>)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Helper method for invoking commands savely
        public void Execute(Command<User> command, User user)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
                command.Execute(user);
            }
        }

		//BINDABLE /IsEnabled
		public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(LoginView), default(bool), BindingMode.OneWay);
		public bool IsEnabled
		{
			get => (bool)GetValue(IsEnabledProperty);
			set { SetValue(IsEnabledProperty, value); }
		}
    }
}
