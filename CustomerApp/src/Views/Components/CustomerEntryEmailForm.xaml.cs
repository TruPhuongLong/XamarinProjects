using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class CustomerEntryEmailForm : ContentView
    {
        public CustomerEntryEmailForm()
        {
            InitializeComponent();
        }

		public event EventHandler<string> ContinueEventHandler;

        void Handle_Clicked(object sender, System.EventArgs e)
		{
			if (ContinueEventHandler != null) ContinueEventHandler(this, "CustomerEntryEmailForm");
        }



        public event EventHandler<string> BackEventHandler;
		void Handle_BackEventHandler(object sender, System.EventArgs e)
		{
			var handler = BackEventHandler;
			if (handler != null) handler(this, "CustomerEntryEmailForm");
		}


		public event EventHandler<string> SkipEventHandler;
		void Handle_SkipEventHandler(object sender, System.EventArgs e)
		{
			if (SkipEventHandler != null) SkipEventHandler(this, "CustomerEntryEmailForm");
		}
    }
}
