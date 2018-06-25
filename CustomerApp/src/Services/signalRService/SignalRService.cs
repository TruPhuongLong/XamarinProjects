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

[assembly: Dependency(typeof(SignalRService))]
namespace CustomerApp.src.Services.signalRService
{
    public class SignalRService
    {
		private IHubProxy hubProxy;
		private AuthService AuthService;

		public SignalRService()
        {
			AuthService = DependencyService.Get<AuthService>();
			Connection();           
        }

		//CONNECT
		public async void Connection()
		{
			HubConnection hubConnection = new HubConnection("http://192.168.0.12/RewardSever");
			hubProxy = hubConnection.CreateHubProxy("ClientHub");
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
		public void OnListCustomersChanged(Action<IAction<Customer[]>> cb)
        {
			hubProxy.On("OnListCustomersChanged",  _listCustomers => {
                try
				{
					Customer[] listCustomers = JsonConvert.DeserializeObject<Customer[]>(_listCustomers);

                    Debug.Write(listCustomers);

					cb(new ListCustomerChangedAction(listCustomers));
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
				await hubProxy.Invoke("PosJoinGroup", AuthService.User.Id);
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
				await hubProxy.Invoke("PosLeaveGroup", AuthService.User.Id);
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
					await hubProxy.Invoke("CustomerJoinGroup", AuthService.User.Id, customer);
				}else{
					await hubProxy.Invoke("CustomerJoinGroup", AuthService.User.Id, JsonConvert.SerializeObject(customer));
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
				await hubProxy.Invoke("CustomerLeaveGroup", AuthService.User.Id, customerId);
                return true;
            }
            catch
            {
                return false;
            }
        }

	}
}