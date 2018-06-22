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
		public User User;
		private DataService DataService;
        
		public AuthService()
        {
			DataService = DependencyService.Get<DataService>();
        }
        
        //LOGIN
		public async Task<bool> Login(User user) 
		{
            var body = "userName=" + user.UserName + "&password=" + user.Password + "&grant_type=password";
			var response = await DataService.Post(GetUri(Constants.URL_LOGIN) ,Encode(body));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

				// save info of user login:
				User = JsonConvert.DeserializeObject<User>(content);

				//save access_token:
				await LocalStorage.SetAccessToken(User.Access_Token);
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



{
  "access_token": "8r8jrg4Sn1YFpclAOxEU1X3El0-BvoDxn-u0RnooUd3WbNclFaE9pZ-bKREE55Q6tGr682tbSpFLaUYP6DKVJXR9I9jWBmDrePaUsIV6r_OtBuKKcOPbVQANj3fqq7vzezv3VRYY14TtMUTYV6p69oZ72a6iflvfJEyZFxz4gFCvt3Tsnz2SvuN9Zwc3ut7wp5UgbfghLDogwP9TSdwrC1kei6KU3t4jn2gY7FcRDcjn-Dd97e-uYbcIjPVRsnHuJNVDXH6yimZG5SVfyBWSv9DE93uv1qI0z-w4d9YblglBIlZi-M6PpEgodWLW8rGA2Now_hsYvc3qP3vtHiPSH8V0LU-Ig1y4gsA1kE5bmAX6ox72jS6OiclPaM7jAblon0Wy8IXicBM8iPGzGt1Zx6qzCzBaASP18xOivelyWaxwAcb0S5tN1thN686xrh4rLEVuSOvyEJ0y7uZol5_0-WLa_uIDPhzVFiphnNgZt3SX3DV9Owx1q_hLUWmmb53APJltIdwGBNrJ8dUd2DHKKm-Lv9Z8BjDJNsCW1wtMLJHGHmJQkPSWDA4CXS19pvgAqfED0Dh_HozOcsNwudYKFnFhNJ7g5rj_cmWK8-MZs3kvc2OhMjZ8okcRE_aMSsshPcUbdA7Hxr0Pwpl_U8y8GGDIWPNU5_FoQdqHxCq6cYT7fanr3_d8gv68caDk3o5SLn2-rLeb5lDQz3tCON5caw",
  "token_type": "bearer",
  "expires_in": 7199,
  "id": "17da9174-9b43-4b98-a79f-b672f2a051ea",
  "fullName": "Blogic systems",
  "avatar": "/assets/images/img.jpg",
  "email": "admin@tedu.com.vn",
  "username": "blogic",
  "phoneNumber": "",
  "birthday": "6/5/2018 9:30:33 AM",
  ".issued": "Thu, 21 Jun 2018 10:29:31 GMT",
  ".expires": "Thu, 21 Jun 2018 12:29:31 GMT"
}
Th

*/
