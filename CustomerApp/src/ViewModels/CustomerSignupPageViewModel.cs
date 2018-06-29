using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using Xamarin.Forms;
using CustomerApp.src.libs;
using CustomerApp.src.Services.ApiServices;

namespace CustomerApp.src.ViewModels
{
	public class CustomerSignupPageViewModel: BaseViewModel
    {
		private CustomerService CustomerService;
		// Implement BaseViewModel:
		public CustomerSignupPageViewModel(ICustomerNavService navService, CustomerService customerService) : base(navService)
        {
			CustomerService = customerService;
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
        private string day;
        public string Day
        {
			get => day;
            set
            {
				SetProperty(ref day, value);
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

        //PROP /errorDateTime
		private string dayOfBirth;
		public string DayOfBirth
        {
			get => dayOfBirth;
            set
            {
				SetProperty(ref dayOfBirth, value);
                SignupCommand.ChangeCanExecute();
            }
        }

        //COMMAND
		private Command signupCommand;
		public Command SignupCommand
		{
			get => signupCommand ?? (signupCommand = new Command(ExecuteCommand, ValidateCommand));	
		}

		async void ExecuteCommand()
		{
			var newCustomer = new Customer();
			newCustomer.MainPhone = MainPhone;
			newCustomer.Email = Email;
			newCustomer.Name = FirstName + " " + LastName;
			//newCustomer.DateOfBirth = (DateTime)FuncHelp.ValidateDateTime(Year, Month, Day).Item2;

			var isSuccess = await CustomerService.Post(newCustomer);
			if(isSuccess)
			{
				// pop customerLoginPage
				await NavService.PreviousPage();
			}
			else
			{
				//notification signup fail
			}
		}

		bool ValidateCommand()
		{
			//var (success, data) = FuncHelp.ValidateDateTime(Year, Month, Day);
			//if(success)
			//{
			//	return true;
			//}
			//return false;


			return true;
		}
	}
}
