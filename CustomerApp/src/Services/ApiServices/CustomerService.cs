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
    //            var content = await response.Content.ReadAsStringAsync();
                
				//// save info of user login:
				//var _customer = JsonConvert.DeserializeObject<Customer>(content);

				//return:
				return true;
            }
            return false;
        }
    }
}
