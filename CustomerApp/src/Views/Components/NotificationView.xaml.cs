using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CustomerApp.src.redux.store;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
	public partial class NotificationView : ContentView
    {
        public NotificationView()
        {
            InitializeComponent();
        }

        //FUNC /property change
		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
			if (propertyName == TriggerProperty.PropertyName)
            {
                if (Trigger)
                {
					((View)ToggledNotificationView.Parent).Notification();
                }
            }
        }

        //BINDABLE /Trigger
		public static readonly BindableProperty TriggerProperty = 
			BindableProperty.Create(nameof(Trigger), typeof(bool), typeof(NotificationView), default(bool), BindingMode.TwoWay);
		public bool Trigger
		{
			get { return (bool)GetValue(TriggerProperty); }
			set { SetValue(TriggerProperty, value); }
		}

        
        //BINDABLE /Message
		public static readonly BindableProperty MessageProperty =
			BindableProperty.Create(nameof(Message), typeof(string), typeof(NotificationView),default(string), BindingMode.TwoWay);
        public string Message
        {
			get { return (string)GetValue(MessageProperty); }
			set { SetValue(MessageProperty, value); }
        }
	}
}
