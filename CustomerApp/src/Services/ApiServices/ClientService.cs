using System;
using System.Net.Http;
using System.Net.Http.Headers;
using CustomerApp.src.libs;
using CustomerApp.src.Services.ApiServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClientService))]
namespace CustomerApp.src.Services.ApiServices
{
    public class ClientService
    {
		private HttpClient current;
		public HttpClient Current
		{
			get => current;
			set { current = value; }
		}

        public ClientService()
        {
			Current = new HttpClient();
			//Current.SetDefaultHeaders();
			Current.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
      
    }


}

static class HttpClientExtensions
{
	public static void SetDefaultHeaders(this HttpClient client)
    {
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.GetAccessToken());
    }
    
	public static void SetHeadersEncode(this HttpClient client)
    {
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
    }
}