using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class PointForm : ContentView
    {
        public PointForm()
        {
            InitializeComponent();
        }

		//PROP
		public static readonly BindableProperty CurrentPointsProperty = BindableProperty.Create(nameof(CurrentPoints), typeof(float), typeof(PointForm),default(float), BindingMode.TwoWay);
		public float CurrentPoints
		{
			get { return (float)GetValue(CurrentPointsProperty); }
			set { SetValue(CurrentPointsProperty, value); }
		}

        //FUCN /down
		void down(object sender, EventArgs args)
		{
			CurrentPoints = CurrentPoints - 1;
		}

        //FUNC /up
		void up(object sender, EventArgs args)
		{
			CurrentPoints = CurrentPoints + 1;
		}
    }
}
