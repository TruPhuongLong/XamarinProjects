using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.libs;
using CustomerApp.src.Models;
using CustomerApp.src.Services.ApiServices;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerService))]
namespace CustomerApp.src.Services.ApiServices
{
    public class CustomerService
    {
		private DataService DataService;
        public CustomerService()
        {
			DataService = DependencyService.Get<DataService>();
        }
        
		//POST customer
		public async Task<bool> Post(Customer customer)
        {
			var uri = Constants.GetUri(Constants.URL_POST_CUSTOMER);
			var stringContent = Constants.EncodeModel(customer);
			var response = await DataService.Post(uri, stringContent);

            if (response != null && response.IsSuccessStatusCode)
            {
				//return:
				return true;
            }
            return false;
        }

		//PUT customer
        public async Task<Customer?> Put(Customer customer)
        {
			var uri = Constants.GetUri(Constants.URL_PATCH_CUSTOMER);
			var stringContent = Constants.EncodeModel(new {customer = customer, sourceRequest = "SunClient"});
			var response = await DataService.Put(uri, stringContent);

            if (response != null && response.IsSuccessStatusCode)
            {
				var content = await response.Content.ReadAsStringAsync();

				if(content != null)
				{
					//get customer already edited from server:
                    var _customer = JsonConvert.DeserializeObject<Customer>(content);

                    return _customer;
				}
            }
            return null;
        }
    }
}
//{customer: this.customer, sourceRequest: "SunClient"}