using System;
using CustomerApp.src.Services.ApiServices;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using CustomerApp.src.libs;

[assembly: Dependency(typeof(AuthService))]
namespace CustomerApp.src.Services.ApiServices
{
	public class AuthService
    {
		public string UserId;
		private DataService DataService;
        
		public AuthService()
        {
			DataService = DependencyService.Get<DataService>();
        }
        
        //LOGIN
		public async Task<HttpResponseMessage> Login<T>(T model)
		{
			return await DataService.Post(model);
		}

        //LOGOUT
		public async Task Logout()
		{
			await LocalStorage.SetAccessToken(null);
		}

        //SIGNUP
		public async Task<HttpResponseMessage> Signup<T>(T model)
		{
			return await DataService.Post(model);
		}
    }
}

/*
 let user: LoggedInUser = response.json();
      if (user && user.access_token) {
        localStorage.removeItem(SystemConstants.CURRENT_USER);
        localStorage.setItem(SystemConstants.CURRENT_USER, JSON.stringify(user));

        // set userId save:
        this.userId = user.id;
        // console.log('set userId when login: ', this.userId)
      }
*/
