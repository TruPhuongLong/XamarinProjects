using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class BasePage : ContentPage
    {
        public BasePage()
        {
            InitializeComponent();
        }

		//BINDABLE
		public static readonly BindableProperty BaseContentViewProperty =
			BindableProperty.Create(nameof(BaseContentView), typeof(View), typeof(BasePage), default(View), BindingMode.TwoWay);
		public View BaseContentView
        {
			get { return (View)GetValue(BaseContentViewProperty); }
			set { SetValue(BaseContentViewProperty, value); }
        }

	}
}
