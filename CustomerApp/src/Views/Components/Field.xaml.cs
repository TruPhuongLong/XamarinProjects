using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

namespace CustomerApp.src.Views.Components
{
	public partial class Field : ContentView
	{
		public Field()
		{
			InitializeComponent();
			entry.TextChanged += OnTextChanged;
		}  

        //FUNC /parent view set value for child and kick up func.
		protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TextProperty.PropertyName)
            {
                entry.Text = Text;

                //validate require
				RequireValidate();

				//validate minlength
				MinlengthValidate();

				//validate isEmail
				IsEmailValidate();

				//validate isNumber
				IsNumberValidate();
            }
        }

		//PROP /Placeholder
		private string placeholder;
		public string Placeholder
        {
			get => placeholder;
			set 
			{
				placeholder = value;
				entry.Placeholder = value;
			}
        }

        //BINDABLE /Text
		public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Field), default(string), BindingMode.TwoWay);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set { SetValue(TextProperty, value);}
        }
		private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Text = e.NewTextValue;
        }

		//ERRORS /private /dictionary
		private Dictionary<string, string> ErrorDic = new Dictionary<string, string>();

		//Errors 
        public FormattedString Errors
        {
			set 
			{
				lableErrors.FormattedText = value;
			}
        }

		//FUNC /update Errors
		private void SetErrors()
		{
			FormattedString fs = new FormattedString();
			double fontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

			foreach (KeyValuePair<string, string> _entry in ErrorDic)
			{
				// do something with entry.Value or entry.Key
				fs.Spans.Add(new Span { Text = _entry.Value + Environment.NewLine, FontSize = fontSize });
			}

			Errors = fs;
		}

		//VALIDATOR /require
		private bool require;
        public bool Require
        {
			get => require;
			set { require = value; }
        }

		//FUNC /call when Text change value;
        void RequireValidate()
        {
            if (!Require) return;
            if (string.IsNullOrEmpty(Text) || string.IsNullOrWhiteSpace(Text))
            {
                if (!ErrorDic.ContainsKey("require"))
                {
                    ErrorDic.Add("require", "* " + Placeholder + " is required");
                }
            }
            else
            {
                if (ErrorDic.ContainsKey("require"))
                {
                    ErrorDic.Remove("require");
                }
            }

            // set errorDic to Errors
            SetErrors();
        }

		//VALIDATOR /minlength
        private string minlength;
        public string Minlength
        {
            get => minlength;
			set { minlength = value; }
        }

        //FUNC /call when Text changed
        void MinlengthValidate()
        {
            int min;
            if (!int.TryParse(Minlength, out min)) return;
            if (Text.Length < (min))
            {
                if (!ErrorDic.ContainsKey("minlength"))
                {
                    ErrorDic.Add("minlength", "* " + Placeholder + " must be at least " + Minlength + " characters");
                }
            }
            else
            {
                if (ErrorDic.ContainsKey("minlength"))
                {
                    ErrorDic.Remove("minlength");
                }
            }

            // set errorDic to Errors
            SetErrors();
        }

		//VALIDATOR /isEmail
        private bool isEmail;
        public bool IsEmail
        {
            get => isEmail;
			set { isEmail = value; }
        }

        //FUNC /call when Text changed
        void IsEmailValidate()
        {
            if (!IsEmail) return;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Text);

            if (!match.Success)
            {
                if (!ErrorDic.ContainsKey("isEmail"))
                {
                    ErrorDic.Add("isEmail", "* Email invalid");
                }
            }
            else
            {
                if (ErrorDic.ContainsKey("isEmail"))
                {
                    ErrorDic.Remove("isEmail");
                }
            }

            // set errorDic to Errors
            SetErrors();
        }

		//VALIDATOR /isNumber
		private bool isNumber;
		public bool IsNumber
        {
			get => isNumber;
			set { isNumber = value; }
        }
        
        //FUNC /call when Text changed
		void IsNumberValidate()
        {
			if (!IsNumber) return;
			int n;
			if (!int.TryParse(Text, out n))
            {
				if (!ErrorDic.ContainsKey("isNumber"))
                {
					ErrorDic.Add("isNumber", "* not a number");
                }
            }
            else
            {
				if (ErrorDic.ContainsKey("isNumber"))
                {
					ErrorDic.Remove("isNumber");
                }
            }

            // set errorDic to Errors
            SetErrors();
        }

	}
}
