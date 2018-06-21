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
				LoginCommand.ChangeCanExecute();
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
				LoginCommand.ChangeCanExecute();
			}
		}

        //COMMAND /login
		Command loginCommand;
        public Command LoginCommand
        {
            get => loginCommand ?? (loginCommand = new Command(ExecuteCommand, ValidatorCommand));
        }

        void ExecuteCommand()
        {
			if (LoginEventHandler != null) LoginEventHandler(this, new User(){Email = Email, Password = Password});
        }

        bool ValidatorCommand()
        {
			return !string.IsNullOrEmpty(Email) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrWhiteSpace(Password);
        }

        //CONSTRUCTOR
		public LoginView_ViewModel()
        {
        }
        
		//EVENT
		public event EventHandler<User> LoginEventHandler;
    }
}
