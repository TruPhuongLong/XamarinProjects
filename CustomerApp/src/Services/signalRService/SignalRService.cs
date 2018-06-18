using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;


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
        
		public void OnPayload(Action<_Action> cb)
		{
			hubProxy.On("payload", (string action) =>
            {
				_Action _action = JsonConvert.DeserializeObject<_Action>(action);
				cb(_action);
            });
		}



    }
}
