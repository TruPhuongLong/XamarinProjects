using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class CustomerRewardView : ContentView
    {
        public CustomerRewardView()
        {
            InitializeComponent();
        }

		public string LabelText
		{
			set { label_name.Text = value; }
		}

		public double RewardPointFontSize
		{
			set { label_currenpoints.FontSize = value; }
		}

		public string RewardPointColor
		{
			set 
			{
				var converter = new ColorTypeConverter();
				label_currenpoints.TextColor = (Color)converter.ConvertFromInvariantString(value); 
			}
		}

        

		public string FontAttributes
        {
			set 
			{ 
				switch(value)
				{
					case "Italic":
						label_currenpoints.FontAttributes = Xamarin.Forms.FontAttributes.Italic; 
                        break;
					case "Bold":
						label_currenpoints.FontAttributes = Xamarin.Forms.FontAttributes.Bold; 
                        break;
					default:
						break;
				}
			}
            
        }

		public static readonly BindableProperty RewardPointProperty = 
			BindableProperty.Create(nameof(RewardPoint), typeof(string), typeof(CustomerRewardView), default(string), BindingMode.OneWay);
		public string RewardPoint
		{
			get => (string)GetValue(RewardPointProperty);
			set { SetValue(RewardPointProperty, value); }
		}
    }
}
