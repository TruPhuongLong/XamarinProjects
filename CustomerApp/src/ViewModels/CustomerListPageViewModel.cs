using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.Services.signalRService;
using Xamarin.Forms;
using CustomerApp.src.redux.actions;

namespace CustomerApp.src.ViewModels
{
	public class CustomerListPageViewModel : BaseViewModel
	{      
		// :================================================================================Data for binding Start:================================================================================

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
				//SaveCommand.ChangeCanExecute();
			}
		}

		string message;
		public string Message
        {
			get => message;
            set
            {
				SetProperty(ref message, value);
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
			//var newCustomer = new Customer { Name = Name, Age = int.Parse(Age) };


			// this is for aspnet.signalr;
			//var result = await signalRService.Connection();
			//         if(result)
			//{
			//	signalRService.OnMessage((mes) => 
			//             {
			//               CustomerLists.Add(new Customer { Name = "long", Message = mes });
			//             });
			//	await signalRService.hubProxy.Invoke("messageAll", Message);
			//}





			//await signalRService.hubProxy.Invoke("MessageAll", null, new[] {Name, Message});


			// store dispatch:
			CustomerStore.Dispath(new AddCustomerAction(new Customer() { Name = Name, Message = Message }));

		}
        
		bool ValidatorCommand()
		{
			//Debug.WriteLine("validation");
			//int NewAge;
			//var ageIsInt = int.TryParse(Age, out NewAge);
			return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Message) ;
		}

		//Detail Command:
		Command<Customer> detailCommand;
		public Command<Customer> DetailCommand
		{
			get => detailCommand ?? (detailCommand = new Command<Customer>
									 (
										 async (customerDetail) =>
				                         await NavService.NavigateToViewModel<CustomerInfoPageViewModel, Customer>(customerDetail))
									);
		}
		// signalr:
		SignalRService signalRService = new SignalRService();

		//:================================================================================ Data for binding End:================================================================================

		 //Implement abstrack class and  constructor:
		public override async Task Init()
		{
			await LoadCustomerListDetail();
		}

		public CustomerListPageViewModel(ICustomerNavService navService) : base(navService)
		{

            
			//signalRService.OnMessage((mes) => 
			//{
			//	CustomerLists.Add(new Customer { Name = "fsfsfs", Message = mes });
			//});

			// this is for aspnetcore.signalr:
            //signalRService.OnMessage((user, mes) =>
            //{
            //    CustomerLists.Add(new Customer { Name = user, Message = mes });
            //});
		}

		public async Task LoadCustomerListDetail()
		{
			//await Task.Run(() =>
			//{
			//	CustomerLists = new ObservableCollection<Customer>()
			//	{
			//		new Customer { Name = "name1" , Message = "hi"}

			//	};
			//});
		}





        

        
	}
}
