using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class CustomerEntryDOBForm : ContentView
    {
        public CustomerEntryDOBForm()
        {
            InitializeComponent();
        }

		public event EventHandler<string> ContinueEventHandler;

        void Handle_Clicked(object sender, System.EventArgs e)
        {
			if (ContinueEventHandler != null) ContinueEventHandler(this, "CustomerEntryDOBForm");
        }




        public event EventHandler<string> BackEventHandler;
        void Handle_BackEventHandler(object sender, System.EventArgs e)
        {
			if (BackEventHandler != null) BackEventHandler(this, "CustomerEntryDOBForm");
        }


        public event EventHandler<string> SkipEventHandler;
        void Handle_SkipEventHandler(object sender, System.EventArgs e)
        {
			if (SkipEventHandler != null) SkipEventHandler(this, "CustomerEntryDOBForm");
        }
    }
}
