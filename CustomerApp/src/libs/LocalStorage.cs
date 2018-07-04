using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomerApp.src.libs
{
	public class LocalStorage
    {
		public static string GetAccessToken()
		{
			var properties = Application.Current.Properties;
			if (properties.ContainsKey(Constants.AccessToken))
			{
				var access_token = properties[Constants.AccessToken] as string;
				if (access_token != null) return access_token;
			}
			return "";
		}

		public static async Task<bool> SetAccessToken(string accees_token)
		{
			try
			{
				var properties = Application.Current.Properties;
				if(properties.ContainsKey(Constants.AccessToken))
				{
					properties.Remove(Constants.AccessToken);
				}

				properties.Add(Constants.AccessToken, accees_token);
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
