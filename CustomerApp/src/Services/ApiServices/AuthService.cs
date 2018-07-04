﻿using System;
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
			var response = await DataService.Post(Constants.GetUri(Constants.URL_LOGIN) ,Constants.EncodeString(body));

			if (response != null && response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

				// save info of user login:
				User = JsonConvert.DeserializeObject<User>(content);

				//save access_token:
				await LocalStorage.SetAccessToken(User.Access_Token);

				//set Authorizationon request header, with access_token just get from server :
				DataService.Client.SetDefaultHeaders();

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
			var result = await DataService.Post(Constants.GetUri(Constants.URL_SIGNUP) ,Constants.EncodeString(body));
			Debug.WriteLine(result);
			return true;
		}

    }
}
