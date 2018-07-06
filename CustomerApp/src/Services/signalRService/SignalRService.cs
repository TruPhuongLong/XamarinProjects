using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using CustomerApp.src.Models;
using CustomerApp.src.Services.ApiServices;
using Xamarin.Forms;
using CustomerApp.src.Services.signalRService;
using CustomerApp.src.redux.actions;
using CustomerApp.src.libs;
using CustomerApp.src.redux.store;

[assembly: Dependency(typeof(SignalRService))]
namespace CustomerApp.src.Services.signalRService
{
    public class SignalRService
    {
		private IHubProxy hubProxy;
		//private AuthService AuthService;

		public SignalRService()
        {
			//AuthService = DependencyService.Get<AuthService>();
			Connection();           
        }

		//CONNECT
		public async void Connection()
		{
			HubConnection hubConnection = new HubConnection(Constants.BASE_URL);
			hubProxy = hubConnection.CreateHubProxy(Constants.HUB_NAME);
            try
            {
                await hubConnection.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
		}
        
        //LISTEN /for Pos
		public void OnListCustomersChanged(Action<IAction> cb)
        {
			hubProxy.On(Constants.OnListCustomersChanged,  _listCustomers => {
                try
				{
					Customer[] listCustomers = JsonConvert.DeserializeObject<Customer[]>(_listCustomers);

                    Debug.Write(listCustomers);

					var newState = new CustomerState();
					newState.CustomerHistory = listCustomers;

					cb(new ListCustomerChangedAction(newState));
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex);
				}

			});
        }

		//INVOKE /Pos join group:
		public async Task<bool> PosJoinGroup()
        {
			try
			{
				await hubProxy.Invoke(Constants.PosJoinGroup, LocalStorage.GetUserId());
				return true;
			}
			catch
			{
				return false;
			}
        }

		//INVOKE /Pos leave group:
		public async Task<bool> PosLeaveGroup()
        {
            try
            {
				await hubProxy.Invoke(Constants.PosLeaveGroup, LocalStorage.GetUserId());
                return true;
            }
            catch
            {
                return false;
            }
        }
        
		//INVOKE /Customer join group:
		public async Task<bool> CustomerJoinGroup<T>(T customer)
        {
            try
            {
				if(customer is string)
				{
					await hubProxy.Invoke(Constants.CustomerJoinGroup, LocalStorage.GetUserId(), customer);
				}else{
					await hubProxy.Invoke(Constants.CustomerJoinGroup, LocalStorage.GetUserId(), JsonConvert.SerializeObject(customer));
				}
                return true;
            }
            catch
            {
                return false;
            }
        }

		//INVOKE /Customer leave group:
		public async Task<bool> CustomerLeaveGroup(string customerId)
        {
            try
            {
				await hubProxy.Invoke(Constants.CustomerLeaveGroup, LocalStorage.GetUserId(), customerId);
                return true;
            }
            catch
            {
                return false;
            }
        }

		//INVOKE /Clear customers:
		public async Task<bool> ClearCustomers()
        {
            try
            {
				await hubProxy.Invoke(Constants.ClearCustomers, LocalStorage.GetUserId());
                return true;
            }
            catch
            {
                return false;
            }
        }

	}
}
