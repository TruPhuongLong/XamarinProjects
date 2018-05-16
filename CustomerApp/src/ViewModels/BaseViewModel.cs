using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CustomerApp.src.Services;
using System.Threading.Tasks;

namespace CustomerApp.src.ViewModels
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		// Implement INotifyPropertyChanged:
		public event PropertyChangedEventHandler PropertyChanged;
		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (Object.Equals(storage, value))
				return false;
			storage = value;
			OnPropertyChanged(propertyName);
			return true;
		}
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		// Get reference to NavService:
		protected ICustomerService NavService { get; private set; }

        //Constructor 
		protected BaseViewModel(ICustomerService navService)
		{
			NavService = navService;
		}

		public abstract Task Init();
	}



	// generic BaseViewModel:
	public abstract class BaseViewModel<TParameter> : BaseViewModel
	{
		protected BaseViewModel(ICustomerService navService) : base(navService)
		{
		}

		public override async Task Init()
		{
			await Init(default(TParameter));
		}

		public abstract Task Init(TParameter parameter);
	}
}



