using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.ViewModels;
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

			Init();
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
			InitNav();

		}

		private void InitNav()
		{
			var rootPage = new NavigationPage(new PosLoginPage() { Title = "Login Pos" });
            var navService = DependencyService.Get<ICustomerNavService>() as CustomerNavService;

            // this point reference navService.navigation to Navigtion -> it importance.
            navService.navigation = rootPage.Navigation;
            

            // Mapping 
			navService.RegisterViewMapping(typeof(PosLoginPageViewModel), typeof(PosLoginPage));
            navService.RegisterViewMapping(typeof(EntryPageViewModel), typeof(EntryPage));
			navService.RegisterViewMapping(typeof(CustomerListPageViewModel), typeof(CustomerListPage));
			navService.RegisterViewMapping(typeof(CustomerLoginPageViewModel), typeof(CustomerLoginPage));
            navService.RegisterViewMapping(typeof(CustomerInfoPageViewModel), typeof(CustomerInfoPage));
			navService.RegisterViewMapping(typeof(CustomerSignupPageViewModel), typeof(CustomerSignupPage));

            //set mainPage:
            MainPage = rootPage;
		}
        

    }
}
