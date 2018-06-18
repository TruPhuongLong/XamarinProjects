using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CustomerApp.src.Services.NavigationService;
using System.Threading.Tasks;
using CustomerApp.src.redux.store;
using CustomerApp.src.Models;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public abstract class CoreBaseViewModel: INotifyPropertyChanged
	{
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
	}

	public abstract class BaseViewModel : CoreBaseViewModel
	{

		// Get reference to NavService:
		protected ICustomerNavService NavService { get; private set; }

        //Constructor 
		protected BaseViewModel(ICustomerNavService navService)
		{
			NavService = navService;
			CustomerStore = InitCustomerStore();
		}

		public abstract Task Init();

		// store:
        public IStore<CustomerState, Customer> CustomerStore { get; set; }

		private IStore<CustomerState, Customer> InitCustomerStore()
        {
            var _CustomerStore = DependencyService.Get<IStore<CustomerState, Customer>>() as CustomerStore;
            return _CustomerStore;
        }
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



