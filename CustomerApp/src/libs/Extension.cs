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
	public static async void Notification(this View view)
    {
		var page = FuncHelp.CurrentPage();
		await view.TranslateTo(- page.Width + 200, 0, 250, Easing.SinInOut);
        await Task.Delay(1600);
        await view.TranslateTo(0, 0, 250, Easing.SinInOut);
    }

	public static void _Add(this RelativeLayout layout, View child)
	{
		layout.Children.Add(child, Constraint.RelativeToParent((parent) => {
            return 0;
        }), Constraint.RelativeToParent((parent) => {
            return 0;
        }), Constraint.RelativeToParent((parent) => {
            return parent.Width;
        }), Constraint.RelativeToParent((parent) => {
            return parent.Height;
        }));
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