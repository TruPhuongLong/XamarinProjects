using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CustomerApp.src.Services.NavigationService;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public class Field_ViewModel : CoreBaseViewModel
	{
		public Field_ViewModel()
		{
		}

		//PROP
		private string text;
		public string Text
		{
			get => text;
			set
			{
				SetProperty(ref text, value);

				//require:
				RequireValidate();

				//minlength:
				MinlengthValidate();

				//IsEmail:
				IsEmailValidate();
			}
		}
        
		//ERRORS /private /dictionary
		private Dictionary<string, string> ErrorDic = new Dictionary<string, string>();

		//ERRORS /for binding
		private FormattedString errors;
		public FormattedString Errors
        {
            get => errors;
            set
            {
                SetProperty(ref errors, value);
            }
        }
        private void SetErrors()
		{
			FormattedString fs = new FormattedString();
			double fontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

			foreach (KeyValuePair<string, string> entry in ErrorDic)
            {
                // do something with entry.Value or entry.Key
				fs.Spans.Add(new Span { Text = entry.Value + Environment.NewLine, FontSize = fontSize });
            }

			Errors = fs;
		}

        //Placeholder
		private string placeholder;
		public string Placeholder
        {
			get => placeholder;
            set
            {
				SetProperty(ref placeholder, value);
            }
        }

		//VALIDATOR:
        // /require
		private bool require;
		public bool Require
        {
			get => require;
            set
            {
				SetProperty(ref require, value);
            }
        }
        void RequireValidate()
		{
			if (!Require) return;
			if (string.IsNullOrEmpty(Text) || string.IsNullOrWhiteSpace(Text))
            {
				if(!ErrorDic.ContainsKey("require")){
					ErrorDic.Add("require","* " + Placeholder + " is required");
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

		//VALIDATOR:
		// /minlength
		private string minlength;
		public string Minlength
        {
			get => minlength;
            set
            {
				SetProperty(ref minlength, value);
            }
        }
		void MinlengthValidate()
        {
			int min;
			if (!int.TryParse(Minlength, out min)) return;
			if (Text.Length < (min))
            {
				if(!ErrorDic.ContainsKey("minlength")){
					ErrorDic.Add("minlength","* " + Placeholder + " must be at least " + Minlength + " characters");
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

		//VALIDATOR:
        // /IsEmail
		private bool isEmail;
		public bool IsEmail
        {
			get => isEmail;
            set
            {
				SetProperty(ref isEmail, value);
            }
        }
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
              
	}
}
