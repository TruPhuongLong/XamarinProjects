using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class CustomerEntryNameForm : ContentView
    {
        public CustomerEntryNameForm()
        {
            InitializeComponent();
        }

		public event EventHandler<string> ContinueEventHandler;

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			if (ContinueEventHandler != null) ContinueEventHandler(this, "CustomerEntryNameForm");
		}

		public event EventHandler<string> BackEventHandler;
		void Handle_BackEventHandler(object sender, string e)
		{
			if (BackEventHandler != null) BackEventHandler(this, "CustomerEntryNameForm");
		}
    }
}
