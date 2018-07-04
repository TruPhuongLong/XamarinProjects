using System;
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
    }

	//class ContentPageExtension
	//{
	//	public static void (this ContentPage contentPage)
	//	{
			
	//	}
	//}
}
