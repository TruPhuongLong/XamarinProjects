using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public class CustomerSignupPageViewModel: BaseViewModel
    {
		// Implement BaseViewModel:
		public CustomerSignupPageViewModel(ICustomerNavService navService) : base(navService)
        {
        }

		public override Task Init()
		{
			throw new NotImplementedException();
		}
        
		//PROP /MainPhone
		private string mainPhone;
		public string MainPhone
        {
			get => mainPhone;
            set
            {
				SetProperty(ref mainPhone, value);
                SignupCommand.ChangeCanExecute();
            }
        }
        
		//PROP /Email
		private string email;
		public string Email
        {
			get => email;
            set
            {
				SetProperty(ref email, value);
                SignupCommand.ChangeCanExecute();
            }
        }

		//PROP /Email
		private string firstName;
		public string FirstName
        {
			get => firstName;
            set
            {
				SetProperty(ref firstName, value);
                SignupCommand.ChangeCanExecute();
            }
        }

		//PROP /Email
		private string lastName;
		public string LastName
        {
			get => lastName;
            set
            {
				SetProperty(ref lastName, value);
                SignupCommand.ChangeCanExecute();
            }
        }

		//PROP /Email
		private string month;
		public string Month
        {
			get => month;
            set
            {
				SetProperty(ref month, value);
                SignupCommand.ChangeCanExecute();
            }
        }

		//PROP /Email
        private string date;
        public string Date
        {
			get => date;
            set
            {
				SetProperty(ref date, value);
                SignupCommand.ChangeCanExecute();
            }
        }

		//PROP /Email
        private string year;
        public string Year
        {
			get => year;
            set
            {
				SetProperty(ref year, value);
                SignupCommand.ChangeCanExecute();
            }
        }

        //COMMAND
		private Command signupCommand;
		public Command SignupCommand
		{
			get => signupCommand ?? (signupCommand = new Command(ExecuteCommand, ValidateCommand));	
		}

		void ExecuteCommand()
		{
			Debug.WriteLine(FirstName + LastName);
		}

		bool ValidateCommand()
		{
			return true;
		}
	}
}
