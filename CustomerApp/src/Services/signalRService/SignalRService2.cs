using System;
using System.Diagnostics;
using CustomerApp.src.libs;
using CustomerApp.src.redux.actions;
using CustomerApp.src.Services.signalRService;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using Xamarin.Forms;
using CustomerApp.src.Models;
using CustomerApp.src.redux.store;
using System.Threading.Tasks;

[assembly: Dependency(typeof(SignalRService2))]
namespace CustomerApp.src.Services.signalRService
{
    public class SignalRService2
    {
		private IHubProxy hubProxy;

        public SignalRService2()
        {
			Connection();  
        }

		//CONNECT
        public async void Connection()
        {
            HubConnection hubConnection = new HubConnection(Constants.BASE_URL);
			hubProxy = hubConnection.CreateHubProxy(Constants.HUB_NAME_2);
            try
            {
                await hubConnection.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

		//LISTEN
		public void OnCustomerChanged(Action<IAction> cb)
        {
			hubProxy.On(Constants.OnCustomersChanged, _Customer => {
                try
                {
					Customer? Customer = null;
					if(_Customer != "")
					{
						Customer = JsonConvert.DeserializeObject<Customer>(_Customer);
					}

                    var newState = new CustomerState();
					newState.Customer = Customer;

                    cb(new CustomerChangedAction(newState));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

            });
        }

		//LISTEN
		public void OnNextStep(Action cb)
        {
			hubProxy.On(Constants.OnNextStep, () => {
				cb();            
            });
        }








		//INVOKE /join group:
        public async Task<bool> JoinGroup()
        {
            try
            {
				var childgroup = LocalStorage.GetChildGroup();
				await hubProxy.Invoke(Constants.JoinGroup, LocalStorage.GetUserId() + childgroup);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //INVOKE /leave group:
        public async Task<bool> LeaveGroup()
        {
            try
            {
				var childgroup = LocalStorage.GetChildGroup();
				await hubProxy.Invoke(Constants.LeaveGroup, LocalStorage.GetUserId() + childgroup);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
		//INVOKE /Customer changed:
		public async Task<bool> CustomersChanged<T>(T customer)
        {
            try
            {
                var childgroup = LocalStorage.GetChildGroup();

				if (customer is string)
                {
					await hubProxy.Invoke(Constants.CustomersChanged, LocalStorage.GetUserId() + childgroup, customer);
                }
                else
                {
					await hubProxy.Invoke(Constants.CustomersChanged, LocalStorage.GetUserId() + childgroup, JsonConvert.SerializeObject(customer));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

		//INVOKE /Next step:
		public async Task<bool> NextStep()
        {
            try
            {
                var childgroup = LocalStorage.GetChildGroup();
				await hubProxy.Invoke(Constants.NextStep, LocalStorage.GetUserId() + childgroup);
                return true;
            }
            catch
            {
                return false;
            }
        }



    }
}

/*
 //join group:
        public async Task<bool> JoinGroup(string group)
        {
            try
            {
                await Groups.Add(Context.ConnectionId, group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //leave group
        public async Task<bool> LeaveGroup(string group)
        {
            try
            {
                await Groups.Remove(Context.ConnectionId, group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Customer send infomation to Pos
        public async Task<bool> CustomersChanged(string group, string customer)
        {
            try
            {
                Customer _customer = JsonConvert.DeserializeObject<Customer>(customer);

                //broadcard to both Pos and Customer.
                Clients.Group(group).OnCustomersChanged(JsonConvert.SerializeObject(_customer));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

//next step
        public async Task<bool> NextStep(string group)
        {
            try
            {
                Clients.Group(group).OnNextStep();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
*/
