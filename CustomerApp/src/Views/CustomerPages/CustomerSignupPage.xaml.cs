using System;
using System.Collections.Generic;
using System.Diagnostics;
using CustomerApp.src.Services.ApiServices;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;
using CustomerApp.src.Views.Components;

namespace CustomerApp.src.Views.CustomerPages
{
    public partial class CustomerSignupPage : ContentPage
    {
		CustomerEntryNameForm nameForm = new CustomerEntryNameForm();
		CustomerEntryEmailForm emailForm = new CustomerEntryEmailForm();
		CustomerEntryDOBForm dOBForm = new CustomerEntryDOBForm();

		CustomerSignupPageViewModel ViewModel
		{
			get => BindingContext as CustomerSignupPageViewModel;
		}

        public CustomerSignupPage()
        {
            InitializeComponent();
			BindingContext = new CustomerSignupPageViewModel(DependencyService.Get<ICustomerNavService>(), DependencyService.Get<CustomerService>());
			Title = "Customer Signup";

			nameForm.ContinueEventHandler += ContinueEventHandler;
			emailForm.ContinueEventHandler += ContinueEventHandler;
			dOBForm.ContinueEventHandler += ContinueEventHandler;

			nameForm.BackEventHandler += BackEventHandler;
			emailForm.BackEventHandler += BackEventHandler;
			dOBForm.BackEventHandler += BackEventHandler;

			emailForm.SkipEventHandler += SkipEventHandler;
			dOBForm.SkipEventHandler += SkipEventHandler;
        }


		async void BackEventHandler(object sender, string id)
		{
			switch(id)
            {
                case "CustomerEntryNameForm":
					ViewModel.BackCustomerLoginPageCommand.Execute(null);
                    break;
                case "CustomerEntryEmailForm":
                    await emailForm.TranslateTo(Width, 0, 250, Easing.CubicInOut);
					await nameForm.TranslateTo(0 , 0, 250, Easing.CubicInOut);
                    break;
                case "CustomerEntryDOBForm":
					await dOBForm.TranslateTo(Width, 0, 250, Easing.CubicInOut);
					await emailForm.TranslateTo(0, 0, 250, Easing.CubicInOut);
                    break;
                default: 
                    break;
            } 
		}


		async void SkipEventHandler(object sender, string id)
        {
			switch(id)
            {
                case "CustomerEntryEmailForm":
                    await emailForm.TranslateTo(-Width, 0, 250, Easing.CubicInOut);
                    await dOBForm.TranslateTo(0 , 0, 250, Easing.CubicInOut);
                    break;
                case "CustomerEntryDOBForm":
                    ViewModel.SignupCommand.Execute(null);
                    break;
                default: 
                    break;
            } 
        }

		async void ContinueEventHandler(object sender, string id)
		{
			switch(id)
			{
				case "CustomerEntryNameForm":
					await nameForm.TranslateTo(-Width, 0, 250, Easing.CubicInOut);
					await emailForm.TranslateTo(0 , 0, 250, Easing.CubicInOut);
					break;
				case "CustomerEntryEmailForm":
					await emailForm.TranslateTo(-Width, 0, 250, Easing.CubicInOut);
					await dOBForm.TranslateTo(0 , 0, 250, Easing.CubicInOut);
                    break;
				case "CustomerEntryDOBForm":
					ViewModel.SignupCommand.Execute(null);
                    break;
				default: 
					break;
			}         
		}
     


		void OnPageSizeChanged(object sender, EventArgs args)
		{         
			RelativeLayout layout = new RelativeLayout();

			layout._Add(nameForm);
			layout._Add(emailForm);
			layout._Add(dOBForm);
         
			this.Content = layout;

			Relocated();
		}

        

        void Relocated()
		{
			nameForm.TranslationX = 0;
			emailForm.TranslationX = Width;
			dOBForm.TranslationX = Width;
		}
        

	}
}
