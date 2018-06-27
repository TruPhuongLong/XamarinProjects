using System;
using CustomerApp.Droid.Views;
using CustomerApp.src.Views.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace CustomerApp.Droid.Views
{
	public class CustomButtonRenderer: ButtonRenderer
    {

    }
}
