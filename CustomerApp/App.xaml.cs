using System;
using CustomerApp.src.Services;
using CustomerApp.src.ViewModels;
using CustomerApp.src.Views.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CustomerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			var rootPage = new NavigationPage(new CustomerListPage(){Title = "Customer List"});
			var navService = DependencyService.Get<ICustomerNavService>() as CustomerNavService;

            // this point reference navService.navigation to Navigtion -> it importance.
			navService.navigation = rootPage.Navigation;

			// Mapping 
			navService.RegisterViewMapping(typeof(CustomerListPageViewModel), typeof(CustomerListPage));
			navService.RegisterViewMapping(typeof(CustomerDetailPageViewModel), typeof(CustomerDetailPage));
			navService.RegisterViewMapping(typeof(CustomerEntryPageViewModel), typeof(CustomerEntryPage));
			navService.RegisterViewMapping(typeof(CustomerSignupPageViewModel), typeof(CustomerSignupPage));

			//set mainPage:
			MainPage = rootPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
