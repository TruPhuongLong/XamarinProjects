﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using Xamarin.Forms;
using CustomerApp.src.libs;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.store;

namespace CustomerApp.src.ViewModels
{
	public class CustomerSignupPageViewModel: BaseViewModel<string>
    {
		private CustomerService CustomerService;
		// Implement BaseViewModel:
		public CustomerSignupPageViewModel(ICustomerNavService navService, CustomerService customerService) : base(navService)
        {
			CustomerService = customerService;
        }

		public override Task Init(string parameter)
		{
			return Task.Run(() => { MainPhone = parameter; });
		}

		public string EmailPart1 { get; set; }
		public string EmailPart2 { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Year { get; set; }

		private string mainPhone;
		public string MainPhone 
		{
			get => mainPhone;
			set { SetProperty(ref mainPhone, value); }
		}


		//COMMAND
		private Command backCustomerLoginPageCommand;
		public Command BackCustomerLoginPageCommand
		{
			get => backCustomerLoginPageCommand ?? (backCustomerLoginPageCommand = new Command(Execute_BackCustomerLoginPageCommand));
		}
		async void Execute_BackCustomerLoginPageCommand()
		{
			await NavService.PreviousPage();
		}

        
        //COMMAND
		private Command signupCommand;
		public Command SignupCommand
		{
			get => signupCommand ?? (signupCommand = new Command(ExecuteCommand));	
		}

		async void ExecuteCommand()
		{
			// trigger up indicator
			((CustomerStore)CustomerStore).Dispath_Indicator(true);

			var newCustomer = GetCustomerValidate();

			if (newCustomer != null)
			{
				var isSuccess = await CustomerService.Post((Customer)newCustomer);
                if (isSuccess)
                {
                    // pop customerLoginPage
                    await NavService.PreviousPage();
                    ((CustomerStore)CustomerStore).Dispath_Notification("save success");
                }
                else
                {
                    //notification signup fail
					((CustomerStore)CustomerStore).Dispath_Notification("signup fail");
                }
			}
                     
			// trigger off indicator
			((CustomerStore)CustomerStore).Dispath_Indicator(false);
		}


		//EVENT
		Customer? GetCustomerValidate()
        {
			var customer = new Customer
			{
				MainPhone = MainPhone,
                Name = FirstName + " " + LastName
            };

			//set email:
			if(!string.IsNullOrEmpty(EmailPart1) && !string.IsNullOrWhiteSpace(EmailPart1) && !string.IsNullOrEmpty(EmailPart1) && !string.IsNullOrWhiteSpace(EmailPart1))
			{
				customer.Email = EmailPart1 + "@" + EmailPart2;
			}


            if (!string.IsNullOrEmpty(Day) || !string.IsNullOrEmpty(Month) || !string.IsNullOrEmpty(Year))
            {
                var (isValidateSuccess, dayOfBirth) = FuncHelp.ValidateDateTime(Year, Month, Day);
                if (isValidateSuccess)
                {
                    customer.DateOfBirth = (DateTime)dayOfBirth;
                }
                else
                {
                    //notification error:
					((CustomerStore)CustomerStore).Dispath_Notification("date time wrong format");

					//then return
					return null;
                }
            }
			else
			{
				customer.DateOfBirth = DateTime.Now;
			}
			return customer;
        }
   
	}
}
