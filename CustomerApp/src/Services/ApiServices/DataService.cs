using System;
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
		private HttpClient Client;

		public DataService()
		{
			Client = DependencyService.Get<ClientService>().Current;
		}

        //GET
		public async Task<HttpResponseMessage> Get()
		{
			return await Client.GetAsync(GetUri());
		}

        //POST
		public async Task<HttpResponseMessage> Post<T>(T model)
        {
			return await Client.PostAsync(GetUri(), GetEncodeModel(model));
        }

        //PUT
		public async Task<HttpResponseMessage> Put<T>(T model)
		{
			return await Client.PutAsync(GetUri(), GetEncodeModel(model));
		}

        //DELETE
		public async Task<HttpResponseMessage> Delete(string id)
		{
			var uri = new Uri(string.Format(Constants.RestUrl, id));
			return await Client.DeleteAsync(uri);
		}


        //PRIVATE func
		private StringContent GetEncodeModel<T>(T model)
		{
			var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
			return content;
		}

		private Uri GetUri()
		{
			return new Uri(string.Format(Constants.RestUrl, string.Empty));
		}
    }
}
