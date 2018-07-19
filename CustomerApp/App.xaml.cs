using CustomerApp.src.libs;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using CustomerApp.src.ViewModels;
using CustomerApp.src.Views.Components;
using CustomerApp.src.Views.CustomerPages;
using CustomerApp.src.Views.PosPages;
using CustomerApp.src.Views.SharePages;
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

			//Init();
			MainPage = new NavigationPage(new CustomerSignupPage());
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

		private void Init()
		{
			InitSignalR();

			InitNav();
		}

		private void InitNav()
		{
			//var rootPage = GetRootPage();  

			var rootPage = new NavigationPage(new PosLoginPage());
            var navService = DependencyService.Get<ICustomerNavService>() as CustomerNavService;

            // this point reference navService.navigation to Navigtion -> it importance.
            navService.navigation = rootPage.Navigation;

            // Mapping /Pos
			navService.RegisterViewMapping(typeof(PosLoginPageViewModel), typeof(PosLoginPage));
            navService.RegisterViewMapping(typeof(EntryPageViewModel), typeof(EntryPage));
			navService.RegisterViewMapping(typeof(CustomerListPageViewModel), typeof(CustomerListPage));
			navService.RegisterViewMapping(typeof(CustomerEditPageViewModel), typeof(CustomerEditPage));

            //Mapping /Customer
			navService.RegisterViewMapping(typeof(CustomerLoginPageViewModel), typeof(CustomerLoginPage));
            navService.RegisterViewMapping(typeof(CustomerInfoPageViewModel), typeof(CustomerInfoPage));
			navService.RegisterViewMapping(typeof(CustomerSignupPageViewModel), typeof(CustomerSignupPage));
			navService.RegisterViewMapping(typeof(CustomerFinishPageViewModel), typeof(CustomerFinishPage));

            //set mainPage:
            MainPage = rootPage;
		}

		//set root page: along with ENV: Pos or Customer
		private Page GetRootPage()
		{
			Page rootPage;
			if (string.IsNullOrEmpty(LocalStorage.GetAccessToken()))
            {
				// first use app, no access_token -> login at first
				rootPage = new PosLoginPage();
            }
            else
            {
                // have access_token: not need to login
                //ENV = Pos
                if (LocalStorage.GetEnviroment() == Constants.POS_ENV)
                {
					rootPage = new CustomerListPage();
                }
                else // ENV = customer
                {
					rootPage = new CustomerLoginPage();
                }
            }
			return new NavigationPage(rootPage);

		}
        
        // init Signalr
		private void InitSignalR()
        {
            DependencyService.Get<SignalRService2>();
        }


    }
}
