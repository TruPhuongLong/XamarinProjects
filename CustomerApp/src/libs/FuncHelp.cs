﻿using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CustomerApp.src.libs
{
    public class FuncHelp
    {
		public static Tuple<bool, DateTime?> ValidateDateTime(string year, string month, string day)
		{
			int y, m, d;
			if(int.TryParse(year, out y) && int.TryParse(month, out m) && int.TryParse(day, out d))
			{
				try
				{
					var date = new DateTime(y, m, d);
					return Tuple.Create<bool, DateTime?>(true, date);
				}
				catch
				{
					return Tuple.Create<bool, DateTime?>(false, null);
				}
			}
			else
			{
				return Tuple.Create<bool, DateTime?>(false, null);	
			}
		}

		//FUNC /get Uri:
        public static Uri GetUri(string url)
        {
            return new Uri(string.Format(url, string.Empty));
        }

        //FUNC /encode
        public static StringContent EncodeString(string data)
        {
            return new StringContent(data, Encoding.UTF8, "application/json");
        }

        public static StringContent EncodeModel<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

		public static Page CurrentPage()
		{
			var Nav = Application.Current.MainPage as NavigationPage;
			return Nav.CurrentPage;
		}

		public static Page GetRootPage()
        {
            var Nav = Application.Current.MainPage as NavigationPage;
			return Nav.RootPage;
        }
    }


	public class DateToDeltaDays : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var dateOfBirth = (DateTime)value;
			var timeForCal = new DateTime(DateTime.Now.Year, dateOfBirth.Month, dateOfBirth.Day);
			var delta = timeForCal - DateTime.Now;
			return delta.Days;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class DeltaDayFormat : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var deltaDays = (int)(new DateToDeltaDays().Convert(value, targetType, parameter, culture));
			return deltaDays > 0 ? deltaDays.ToString() + " days" : "today";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class Not : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}
	}

	public class ObjToBool : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value != null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
