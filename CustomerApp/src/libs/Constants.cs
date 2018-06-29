using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace CustomerApp.src.libs
{
    public class Constants
    {
		//BASE URL
		public static string BASE_URL = "http://192.168.0.12/RewardSever";

        //AUTH URL
		public static string URL_LOGIN = BASE_URL + "/api/oauth/token";
		public static string URL_SIGNUP = BASE_URL + "/api/appUser/add";

		public static string AccessToken = "ACCESS_TOKEN";

		//CUSTOMER URL
		public static string URL_LOGIN_CUSTOMER = BASE_URL + "/api/customer/GetByPhoneNumber?phoneNumber=";
		public static string URL_POST_CUSTOMER = BASE_URL + "/api/customer/postNewCustomerForXamarin";

		//FUNC /get Uri:
		public static Uri GetUri(string url)
        {
            return new Uri(string.Format(url, string.Empty));
        }

		//FUNC /encode
		public static StringContent EncodeString(string data)
        {
            return new StringContent(data, Encoding.UTF8, "application/json");
        }

		public static StringContent EncodeModel<T>(T data)
        {
			var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }




        //======HUB=====

        //Hub name:
        public static string HUB_NAME = "ClientHub";

		//Hub /func name in app for hub call:
		public static string OnListCustomersChanged = "OnListCustomersChanged";

		//Hub /func name in hub for app call:
		public static string PosJoinGroup = "PosJoinGroup";
		public static string PosLeaveGroup = "PosLeaveGroup";
		public static string CustomerJoinGroup = "CustomerJoinGroup";
		public static string CustomerLeaveGroup = "CustomerLeaveGroup";

    }
}
