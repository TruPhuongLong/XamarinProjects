using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CustomerApp.src.libs;
using Xamarin.Forms;

//View extension
static class ViewExtension
{
	public static async void Notification(this View view, double widthOfDevice)
    {
		await view.TranslateTo(widthOfDevice - view.Width , view.Y, 250, Easing.SinInOut);
		await Task.Delay(1600);
		await view.TranslateTo(widthOfDevice + 10, view.Y, 250, Easing.SinInOut);
    }
}


//HttpClient extension
static class HttpClientExtension
{
    public static void SetDefaultHeaders(this HttpClient client)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.GetAccessToken());
    }

    public static void SetHeadersEncode(this HttpClient client)
    {
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
    }
}