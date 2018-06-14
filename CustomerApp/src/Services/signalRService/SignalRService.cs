using System;
using System.Diagnostics;
//using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;


namespace CustomerApp.src.Services.signalRService
{
    public class SignalRService
    {
		public IHubProxy hubProxy;
		public HubConnection hubConnection;
		public SignalRService()
        {
			hubConnection = new HubConnection("http://192.168.0.25:5000");
			hubProxy = hubConnection.CreateHubProxy("ChatHub");
            try
			{
				hubConnection.Start();
			} catch (Exception ex) {
				Debug.WriteLine(ex);
            }
            
        }
        
		public void OnMessage(Action<string, string> cb)
		{
			hubProxy.On("message", (string user, string message) =>
            {
				cb(user, message);
            });
		}



    }
}
