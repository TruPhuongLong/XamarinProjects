using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using CustomerApp.src.redux.actions;

namespace CustomerApp.src.Services.signalRService
{
    public class SignalRService
    {
		public IHubProxy hubProxy;
		public HubConnection hubConnection;

		public SignalRService()
        {
			var result = Connection();            
        }

		public async Task<bool> Connection()
		{
			hubConnection = new HubConnection("http://192.168.0.12/RewardSever");
			hubProxy = hubConnection.CreateHubProxy("ClientHub");
            try
            {
                await hubConnection.Start();
				return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
				return false;
            }
		}
        
		//func only for Pos 
		// need swicth: action.type
		// type: AddCustomer -> add action.payload
		// type: RemoveCustomer -> remove action.payload
		public void OnAction<T>(Action<IAction<T>> cb)
		{
			hubProxy.On("OnAction", (string action_json) =>
            {
				IAction<T> action = JsonConvert.DeserializeObject<IAction<T>>(action_json);
				cb(action);
            });
		}
        
		// func only for Pos:
		public async Task<bool> PosJoinGroup(string group)
		{
			try
			{
				await hubProxy.Invoke("PosJoinGroup", group);
				return true;
			}
			catch
			{
				return false;
			}
		}

		// func only for Customer:
		public async Task<bool> CustomerMessageToPosGroup(string group, string payload)
        {
            try
			{
				await hubProxy.Invoke("CustomerMessageToPosGroup", group, payload);
				return true;
			}
			catch 
			{
				return false;
			}
		}

	}
}
