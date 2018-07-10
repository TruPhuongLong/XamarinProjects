using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class ReviewView : ContentView
    {
        public ReviewView()
        {
            InitializeComponent();
        }

		public static readonly BindableProperty ReviewProperty = BindableProperty.Create(nameof(Review), typeof(string), typeof(ReviewView), default(string), BindingMode.TwoWay);
        public string Review
		{
			get => (string)GetValue(ReviewProperty);
			set { SetValue(ReviewProperty, value); }
		}
    }
}
