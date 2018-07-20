using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class HeaderForm : ContentView
    {
        public HeaderForm()
        {
            InitializeComponent();
        }

		public string Header
		{
			set { header.Review = value; }
		}

		public double HeaderFontSize
		{
			set { header.FontSize = value; }
		}

		//COMMAND /back
		public static readonly BindableProperty BackProperty = BindableProperty.Create(nameof(Back), typeof(Command), typeof(HeaderForm), default(Command), BindingMode.TwoWay);
		public Command Back
		{
			get => (Command)GetValue(BackProperty);
			set { SetValue(BackProperty, value); }
		}



		//COMMAND /skip
		public static readonly BindableProperty SkipProperty = BindableProperty.Create(nameof(Skip), typeof(Command), typeof(HeaderForm), default(Command), BindingMode.TwoWay);
        public Command Skip
        {
			get => (Command)GetValue(SkipProperty);
			set { SetValue(SkipProperty, value); }
        }

        //PROP
		public string BackParameter { get; set; }

        //PROP
		public string SkipParameter { get; set; }
        
		//PROP /show or hide skip button
		public bool IsShowSkip
		{
			set
			{
				btnskip.IsVisible = value;
				btnskip.IsEnabled = value;
			}
		}
        
        //EVENT
		public event EventHandler BackEventHandler;
		void Handle_Clicked_Back(object sender, System.EventArgs e)
		{
			if (BackEventHandler != null) BackEventHandler(this, e);

		}

		//EVENT
        public event EventHandler SkipEventHandler;
        void Handle_Clicked_Skip(object sender, System.EventArgs e)
        {
			if (SkipEventHandler != null) SkipEventHandler(this, null);
        }

    }
}
