using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CustomerApp.src.Services.NavigationService;
using System.Threading.Tasks;

namespace CustomerApp.src.ViewModels
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		// :===========================================Implement INotifyPropertyChanged for binding:  Start===========================================
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
		// :===========================================Implement INotifyPropertyChanged for binding:  End===========================================

		// Get reference to NavService:
		protected ICustomerNavService NavService { get; private set; }

        //Constructor 
		protected BaseViewModel(ICustomerNavService navService)
		{
			NavService = navService;
		}

		public abstract Task Init();
	}



	// generic BaseViewModel:
	public abstract class BaseViewModel<TParameter> : BaseViewModel
	{
		protected BaseViewModel(ICustomerNavService navService) : base(navService)
		{
		}

		public override async Task Init()
		{
			await Init(default(TParameter));
		}

		public abstract Task Init(TParameter parameter);
	}
}



