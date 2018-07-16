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
				ErrorDic = RequireValidate(ErrorDic);

				//validate minlength
				ErrorDic = MinlengthValidate(ErrorDic);

				//validate isEmail
				ErrorDic = IsEmailValidate(ErrorDic);

				//validate isNumber
				ErrorDic = IsNumberValidate(ErrorDic);

				//finaly we set errors string to show uesr:
				SetErrors();
            }
        }

        //PROP /HeightRequest
		public double _HeightRequest
		{
			set
			{
				entry.HeightRequest = value;
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

		//PROP /IsPassword
		public bool IsPassword
		{
			set { entry.IsPassword = value; }
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
		//public Dictionary<string, string> ErrorDic = new Dictionary<string, string>();
		public static readonly BindableProperty ErrorDicProperty = 
			BindableProperty.Create(nameof(ErrorDic), typeof(Dictionary<string, string>), typeof(Field), new Dictionary<string, string>(), BindingMode.OneWayToSource);
		public Dictionary<string, string> ErrorDic
        {
			get => (Dictionary<string, string>)GetValue(ErrorDicProperty);
			set { SetValue(ErrorDicProperty, value); }
        }
        

		//Errors 
		private FormattedString Errors
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
			set 
			{ 
				require = value;
				ErrorDic = RequireValidate(ErrorDic);
			}
        }

		//FUNC /call when Text change value;
		Dictionary<string, string> RequireValidate(Dictionary<string, string> errorDic)
        {
			if (!Require) return errorDic;
            
            //copy 
			var newErrorDic = new Dictionary<string, string>(errorDic);

            if (string.IsNullOrEmpty(Text) || string.IsNullOrWhiteSpace(Text))
            {
				if (!newErrorDic.ContainsKey("require"))
                {
					newErrorDic.Add("require", "* " + Placeholder + " is required");
                }
            }
            else
            {
				if (newErrorDic.ContainsKey("require"))
                {
					newErrorDic.Remove("require");
                }
            }

            //return new ErrorDic
            return newErrorDic;
        }

		//VALIDATOR /minlength
        private string minlength;
        public string Minlength
        {
            get => minlength;
			set 
			{ 
				minlength = value; 
				ErrorDic = RequireValidate(ErrorDic);
			}
        }

        //FUNC /call when Text changed
		Dictionary<string, string> MinlengthValidate(Dictionary<string, string> errorDic)
        {
            int min;
			if (!int.TryParse(Minlength, out min)) return errorDic;

			//copy 
            var newErrorDic = new Dictionary<string, string>(errorDic);

            if (Text.Length < (min))
            {
				if (!newErrorDic.ContainsKey("minlength"))
                {
					newErrorDic.Add("minlength", "* " + Placeholder + " must be at least " + Minlength + " characters");
                }
            }
            else
            {
				if (newErrorDic.ContainsKey("minlength"))
                {
					newErrorDic.Remove("minlength");
                }
            }
         
			return newErrorDic;
        }
        
		//VALIDATOR /isEmail
        private bool isEmail;
        public bool IsEmail
        {
            get => isEmail;
			set 
			{ 
				isEmail = value; 
				ErrorDic = RequireValidate(ErrorDic);
			}
        }

        //FUNC /call when Text changed
		Dictionary<string, string> IsEmailValidate(Dictionary<string, string> errorDic)
        {
			if (!IsEmail) return errorDic;

			//copy 
            var newErrorDic = new Dictionary<string, string>(errorDic);

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Text);

            if (!match.Success)
            {
				if (!newErrorDic.ContainsKey("isEmail"))
                {
					newErrorDic.Add("isEmail", "* Email invalid");
                }
            }
            else
            {
				if (newErrorDic.ContainsKey("isEmail"))
                {
					newErrorDic.Remove("isEmail");
                }
            }
         
			return newErrorDic;
        }

		//VALIDATOR /isNumber
		private bool isNumber;
		public bool IsNumber
        {
			get => isNumber;
			set 
			{ 
				isNumber = value;
				ErrorDic = RequireValidate(ErrorDic);
			}
        }
        
        //FUNC /call when Text changed
		Dictionary<string, string> IsNumberValidate(Dictionary<string, string> errorDic)
        {
			if (!IsNumber) return errorDic;

			//copy 
            var newErrorDic = new Dictionary<string, string>(errorDic);

			int n;
			if (!int.TryParse(Text, out n))
            {
				if (!newErrorDic.ContainsKey("isNumber"))
                {
					newErrorDic.Add("isNumber", "* not a number");
                }
            }
            else
            {
				if (newErrorDic.ContainsKey("isNumber"))
                {
					newErrorDic.Remove("isNumber");
                }
            }
         
			return newErrorDic;
        }

	}
}
