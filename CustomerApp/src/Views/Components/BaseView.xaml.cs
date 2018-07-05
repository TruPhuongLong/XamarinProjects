using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class BaseView : ContentView
    {
        public BaseView()
        {
            InitializeComponent();
        }

		public static BindableProperty BaseContentProperty = BindableProperty.Create(nameof(BaseContent), typeof(View), typeof(BaseView));

        public View BaseContent
        {
			get { return (View)GetValue(BaseContentProperty); }
			set { SetValue(BaseContentProperty, value); }
        }

    }
}
