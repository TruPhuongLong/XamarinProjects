using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.src.libs;
using CustomerApp.src.Services.ApiServices;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataService))]
namespace CustomerApp.src.Services.ApiServices
{
    public class DataService
    {
		public HttpClient Client;
		public bool IsLoading = false;

		public DataService()
		{
			Client = DependencyService.Get<ClientService>().Current;
		}

        //GET
		public async Task<HttpResponseMessage> Get(string url)
		{
			IsLoading = true;
			var result = await Client.GetAsync(GetUri(url));
			IsLoading = false;
			return result;
		}

        //POST
		public async Task<HttpResponseMessage> Post(Uri uri, StringContent content)
        {
			IsLoading = true;
			var result = await Client.PostAsync(uri, content);
            IsLoading = false;
            return result;
        }

        //PUT
		public async Task<HttpResponseMessage> Put(Uri uri, StringContent content)
		{
			IsLoading = true;
			var result = await Client.PutAsync(uri, content);
            IsLoading = false;
            return result;
		}

        //DELETE
		public async Task<HttpResponseMessage> Delete(Uri uri)
		{
			IsLoading = true;
			var result = await Client.DeleteAsync(uri);
            IsLoading = false;
            return result;
		}

		private Uri GetUri(string url)
        {
            return new Uri(string.Format(url, string.Empty));
        }


    }
}

/*
var response = await DataService.Get(GetUri("https://jsonplaceholder.typicode.com/users"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject(content);
                Debug.WriteLine(Items);
            }
*/
