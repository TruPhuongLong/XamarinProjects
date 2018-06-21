using System;
using CustomerApp.src.Services.ApiServices;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using CustomerApp.src.libs;
using Newtonsoft.Json;
using System.Text;
using CustomerApp.src.Models;
using System.Diagnostics;

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
		public async Task<bool> Login(User user) 
		{
            var body = "userName=" + user.UserName + "&password=" + user.Password + "&grant_type=password";
			DataService.Client.SetHeadersEncode();
			var response = await DataService.Post(GetUri(Constants.URL_LOGIN) ,Encode(body)).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject(content);
                Debug.WriteLine(Items);
				return true;
            }
			return false;
		}
        
        //LOGOUT
		public async Task Logout()
		{
			await LocalStorage.SetAccessToken(null);
		}
        
        //SIGNUP
		public async Task<bool> Signup(User user)
		{
			var body = "userName=" + user.UserName + "&email=" + user.Email +  "&password=" + user.Password + "&grant_type=password";
            DataService.Client.SetHeadersEncode();
			var result = await DataService.Post(GetUri(Constants.URL_SIGNUP) ,Encode(body));
			Debug.WriteLine(result);
			return true;
		}

		private Uri GetUri(string url)
        {
			return new Uri(string.Format(url, string.Empty));
        }

        
        //PRIVATE func
		private StringContent Encode(string data)
        {
            return new StringContent(data, Encoding.UTF8, "application/json");
        }
    }
}

/*


 let body = "userName=" + encodeURIComponent(userName) +
      "&password=" + encodeURIComponent(passWord) +
      "&grant_type=password";
    let header = new Headers();
    header.append("Content-Type", "application/x-www-form-urlencoded");
    let options: RequestOptions = new RequestOptions({ headers: header });
    return this._http.post(SystemConstants.BASE_API + '/api/oauth/token', body, options).map((response: Response) => {
      let user: LoggedInUser = response.json();
      if (user && user.access_token) {
        localStorage.removeItem(SystemConstants.CURRENT_USER);
        localStorage.setItem(SystemConstants.CURRENT_USER, JSON.stringify(user));

        // set userId save:
        this.userId = user.id;
        // console.log('set userId when login: ', this.userId)
      }
    });

let body = "userName=" + encodeURIComponent(model.userName) +
      "&email=" + encodeURIComponent(model.email) +
      "&password=" + encodeURIComponent(model.password) +
      "&grant_type=password";
    let header = new Headers();
    header.append("Content-Type", "application/x-www-form-urlencoded");
    let options: RequestOptions = new RequestOptions({ headers: header });
    return this._http.post(SystemConstants.BASE_API + '/api/appUser/add', body, options)
      .toPromise()
      .catch(error => {
        console.log(error)
      })

*/
