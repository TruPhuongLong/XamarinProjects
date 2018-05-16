using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services;
using Xamarin.Forms;

namespace CustomerApp.src.ViewModels
{
	public class CustomerListPageViewModel : BaseViewModel
	{
		// :================================================================================Data for binding Start:================================================================================
		ObservableCollection<Customer> customerLists;
		public ObservableCollection<Customer> CustomerLists
		{
			get => customerLists;
			set
			{
				SetProperty(ref customerLists, value);
			}
		}

		string name;
		public string Name
		{
			get => name;
			set
			{
				SetProperty(ref name, value);
				SaveCommand.ChangeCanExecute();
			}
		}

		string age;
		public string Age
		{
			get => age;
			set
			{
				SetProperty(ref age, value);
				SaveCommand.ChangeCanExecute();
			}
		}

		//Save Command:
		Command saveCommand;
		public Command SaveCommand
		{
			get => saveCommand ?? (saveCommand = new Command(ExecuteCommand, ValidatorCommand));
		}

		void ExecuteCommand()
		{
			// create object get from user:
			Debug.WriteLine("ExecuteCommand");
			// sure Age is Int because Validator make that; so use int.Parse is save.
			var newCustomer = new Customer { Name = Name, Age = int.Parse(Age) };
		}

		bool ValidatorCommand()
		{
			Debug.WriteLine("validation");
			int NewAge;
			var ageIsInt = int.TryParse(Age, out NewAge);
			return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Age) && ageIsInt;
		}

		//Detail Command:
		Command<Customer> detailCommand;
		public Command<Customer> DetailCommand
		{
			get => detailCommand ?? (detailCommand = new Command<Customer>
									 (
										 async (customerDetail) =>
										 await NavService.NavigateToViewModel<CustomerDetailPageViewModel, Customer>(customerDetail))
									);
		}
		//:================================================================================ Data for binding End:================================================================================

		// Implement abstrack class and  constructor:
		public override async Task Init()
		{
			await LoadCustomerListDetail();
		}

		public CustomerListPageViewModel(ICustomerNavService navService) : base(navService)
		{
			CustomerLists = new ObservableCollection<Customer>();
		}

		public async Task LoadCustomerListDetail()
		{
			await Task.Run(() =>
			{
				CustomerLists = new ObservableCollection<Customer>()
				{
					new Customer { Name = "name1", Age = 20 },
					new Customer { Name = "name2", Age = 30 },
					new Customer { Name = "name3", Age = 40 },
					new Customer { Name = "name4", Age = 25 },
					new Customer { Name = "name5", Age = 60 },
					new Customer { Name = "name6", Age = 23 },
					new Customer { Name = "name7", Age = 29 }
				};
			});
		}
	}
}
