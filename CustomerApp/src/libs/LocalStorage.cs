using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomerApp.src.libs
{
	public class LocalStorage
    {
        //SET /reset
		public static async Task Reset()
		{
			await SetAccessToken(null);
			await SetUserId(null);
			await SetEnviroment(null);
		}

		//GET /access_token
		public static string GetAccessToken()
		{
			return Get(Constants.AccessToken);
		}

        //SET /access_token
		public static async Task<bool> SetAccessToken(string accees_token)
		{
			return await Set(Constants.AccessToken, accees_token);
		}

		//SET /enviroment for app: Pos or Customer
		public static async Task<bool> SetEnviroment(string env)
		{
			return await Set(Constants.WHO_AM_I_KEY, env);
		}

		//GET /enviroment
		public static string GetEnviroment()
        {        
			return Get(Constants.WHO_AM_I_KEY);
        }

		//SET /userid
        public static async Task<bool> SetUserId(string userid)
        {
			return await Set(Constants.USER_ID_KEY, userid);
        }

        //GET /userid
		public static string GetUserId()
        {
			return Get(Constants.USER_ID_KEY);
        }

		//SET /name childgroup
        public static async Task<bool> SetChildGroup(string childgroup)
        {
			return await Set(Constants.ChildGroupKey, childgroup);
        }

        //GET /name childgroup
		public static string GetChildGroup()
        {
			return Get(Constants.ChildGroupKey);
        }

        

		private static string Get(string key)
		{
			var properties = Application.Current.Properties;
            if (properties.ContainsKey(key))
            {
                var value = properties[key] as string;
				if (value != null) return value;
            }
            return "";
		}

		public static async Task<bool> Set(string key, string value)
        {
            try
            {
                var properties = Application.Current.Properties;
				properties[key] = value;
                await Application.Current.SavePropertiesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
