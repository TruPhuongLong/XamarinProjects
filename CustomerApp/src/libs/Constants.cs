using System;
namespace CustomerApp.src.libs
{
    public class Constants
    {
		public static string BASE_URL = "http://192.168.0.12/RewardSever";
		public static string URL_LOGIN = BASE_URL + "/api/oauth/token";
		public static string URL_SIGNUP = BASE_URL + "/api/appUser/add";
		public static string URL_LOGIN_CUSTOMER = BASE_URL + "/api/customer/GetByPhoneNumber?phoneNumber=";

		public static string AccessToken = "ACCESS_TOKEN"; 
    }
}
