using System;
using System.Diagnostics;
using CustomerApp.src.Models;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public class LoginView_ViewModel: CoreBaseViewModel
    {
		//PROP /Email
		string email;
        public string Email
		{
			get => email;
			set
			{
				SetProperty(ref email, value);
				_LoginCommand.ChangeCanExecute();
			}
		}

		//PROP /UserName
		string userName;
		public string UserName
        {
			get => userName;
            set
            {
				SetProperty(ref userName, value);
                _LoginCommand.ChangeCanExecute();
            }
        }

		//PROP /Password
		string password;
		public string Password
		{
			get => password;
			set
			{
				SetProperty(ref password, value);
				_LoginCommand.ChangeCanExecute();
			}
		}

        //COMMAND /login
		Command loginCommand;
        public Command _LoginCommand
        {
            get => loginCommand ?? (loginCommand = new Command(ExecuteCommand, ValidatorCommand));
        }

        void ExecuteCommand()
        {
			if (LoginEventHandler != null) LoginEventHandler(this, new User(){Email = Email, UserName = UserName, Password = Password});
        }

        bool ValidatorCommand()
        {
			return !string.IsNullOrEmpty(UserName) && !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrWhiteSpace(Password);
        }

        //CONSTRUCTOR
		public LoginView_ViewModel()
        {
        }
        
		//EVENT
		public event EventHandler<User> LoginEventHandler;
    }
}
