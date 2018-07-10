using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
    public partial class EntryNumberView : ContentView
    {
        public EntryNumberView()
        {
            InitializeComponent();
        }
        
		//PROP
        public int SizeButton { get; set; } = 100;

		//BINDABLE /for binding:
		public static readonly BindableProperty NumberProperty = BindableProperty.Create(nameof(Number), typeof(string), typeof(EntryNumberView), default(string), BindingMode.TwoWay);
        public string Number
        {
			get { return (string)GetValue(NumberProperty); }
			set { SetValue(NumberProperty, value); }
        }

		//FUNC /number pick
        void OnPickNumber(object sender, EventArgs args)
        {
            Button btn = (Button)sender;
            switch (btn.StyleId)
            {
                case "Clear":
                    Clear();
                    break;
                default:
                    Add(btn.StyleId);
                    break;
            }
        }

        //FUNC /Clear /private 
        private void Clear()
        {
			if (Number == "") return;
			Number = "";
        }

        //FUNC /Add /private 
        private void Add(string styleId)
        {
			Number = Number + styleId;
        }
    }
}
