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
			hubConnection = new HubConnection("http://192.168.0.25:5000");
			hubProxy = hubConnection.CreateHubProxy("ChatHub");
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
        
		public void OnPayload<T>(Action<IAction<T>> cb)
		{
			hubProxy.On("Payload", (string action_json) =>
            {
				IAction<T> action = JsonConvert.DeserializeObject<IAction<T>>(action_json);
				cb(action);
            });
		}
        


    }
}
