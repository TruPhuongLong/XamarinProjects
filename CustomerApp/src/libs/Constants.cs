using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace CustomerApp.src.libs
{
    public class Constants
    {
		//BASE URL
		public static string BASE_URL = "http://192.168.0.8/RewardSever";

        //AUTH URL
		public static string URL_LOGIN = BASE_URL + "/api/oauth/token";
		public static string URL_SIGNUP = BASE_URL + "/api/appUser/add";
        
		//CUSTOMER URL
		public static string URL_LOGIN_CUSTOMER = BASE_URL + "/api/customer/GetByPhoneNumber?phoneNumber=";
		public static string URL_POST_CUSTOMER = BASE_URL + "/api/customer/postNewCustomerForXamarin";
		public static string URL_PATCH_CUSTOMER = BASE_URL + "/api/customer/editCurrentCustomer";      

		//LOCAL / for app use data local
		public static string USER_ID_KEY = "USER_ID_KEY";
		public static string AccessToken = "ACCESS_TOKEN";
		public static string WHO_AM_I_KEY = "whoamiKey";
		public static string POS_ENV = "POS_ENV";
		public static string CUSTOMER_ENV = "CUSTOMER_ENV";



        //======HUB =====

        //Hub name:
        public static string HUB_NAME = "ClientHub";

		//Hub /func name in app for hub call:
		public static string OnListCustomersChanged = "OnListCustomersChanged";

		//Hub /func name in hub for app call:
		public static string PosJoinGroup = "PosJoinGroup";
		public static string PosLeaveGroup = "PosLeaveGroup";
		public static string CustomerJoinGroup = "CustomerJoinGroup";
		public static string CustomerLeaveGroup = "CustomerLeaveGroup";
		public static string ClearCustomers = "ClearCustomers";


		//=======HUB 2 ======
		//Hub name:
		public static string HUB_NAME_2 = "ClientHub2";

		//Hub /func name in app for hub call:
		public static string OnCustomersChanged = "OnCustomersChanged";
		public static string OnNextStep = "OnNextStep";


		//Hub /func name in hub for app call:
		public static string JoinGroup = "JoinGroup";
		public static string LeaveGroup = "LeaveGroup";
		public static string CustomersChanged = "CustomersChanged";
		public static string NextStep = "NextStep";

		//key for Child group
		public static string ChildGroupKey = "ChildGroupKey";
    }
}
