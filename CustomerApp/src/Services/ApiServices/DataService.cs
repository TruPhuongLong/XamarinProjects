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
            try
			{
				IsLoading = true;
                var result = await Client.GetAsync(FuncHelp.GetUri(url));
                IsLoading = false;
                return result;
			}
			catch
			{
				return null;
			}
		}

		//POST
		public async Task<HttpResponseMessage> Post(Uri uri, StringContent content)
        {         
			try
            {
				IsLoading = true;
                var result = await Client.PostAsync(uri, content);
                IsLoading = false;
                return result;
            }
            catch 
            {
				return null;
            }
        }
        
        //PUT
		public async Task<HttpResponseMessage> Put(Uri uri, StringContent content)
		{
			try
            {
				IsLoading = true;
                var result = await Client.PutAsync(uri, content);
                IsLoading = false;
                return result;
            }
            catch
            {
                return null;
            }
		}

        //DELETE
		public async Task<HttpResponseMessage> Delete(Uri uri)
		{
			IsLoading = true;
			var result = await Client.DeleteAsync(uri);
            IsLoading = false;
            return result;
		}

    }
}
