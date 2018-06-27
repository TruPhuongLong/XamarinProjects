using System;
using CustomerApp.iOS.Views;
using CustomerApp.src.Views.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace CustomerApp.iOS.Views
{
	public class CustomButtonRenderer: ButtonRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);
            Control.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap;
            Control.TitleLabel.TextAlignment = UITextAlignment.Center;
		}
	}
}
