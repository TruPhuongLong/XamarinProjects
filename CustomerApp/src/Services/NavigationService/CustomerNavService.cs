using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CustomerApp.src.Models;
using CustomerApp.src.redux.store;
using CustomerApp.src.Services.NavigationService;
using CustomerApp.src.ViewModels;
using Xamarin.Forms;

// this class is capsulate
// and only viewModel point to it, to get action with navigation to control Page (push pop)

// this Dependency come from Xamarin.Form, this mean you can call ICustomerService to get CustomerNavService
[assembly: Dependency(typeof(CustomerNavService))]
namespace CustomerApp.src.Services.NavigationService
{
	public class CustomerNavService : ICustomerNavService
	{
		// pass Xamarin.Form Navigation to this variable, and use this variable to handle app.
		public INavigation navigation { get; set; }
		readonly IDictionary<Type, Type> viewMapping = new Dictionary<Type, Type>();



		// add paired (viewModel - view) for map push to view.
		public void RegisterViewMapping(Type viewModel, Type view)
		{
			viewMapping.Add(viewModel, view);
		}

		// Implement Interface:

		public async Task NavigateToViewModel<ViewModel>() where ViewModel : BaseViewModel
        {
			Type viewType;
            if (viewMapping.TryGetValue(typeof(ViewModel), out viewType))
            {
                // get constructor with parameterLess from Type.
                var constructor = viewType.GetTypeInfo()
                                          .DeclaredConstructors
                                          .FirstOrDefault(declareConstructor => declareConstructor.GetParameters().Count() <= 0);
                var view = constructor.Invoke(null) as Page;
                await navigation.PushAsync(view, true);
            } 
        }

		public async Task NavigateToViewModel<ViewModel, TParameter>(TParameter parameter) where ViewModel : BaseViewModel<TParameter>
		{
			await NavigateToViewModel<ViewModel>();			       

			// after push:
			if (navigation.NavigationStack.Last().BindingContext is BaseViewModel<TParameter>)
			{
				await ((BaseViewModel<TParameter>)navigation.NavigationStack.Last().BindingContext).Init(parameter);
			}
		}

		public async Task PreviousPage()
		{
			// check navigation stack ok for new action:
			if (navigation.NavigationStack != null && navigation.NavigationStack.Count > 0)
			{
				await navigation.PopAsync(true);
			}
		}

		public async Task BackToMainPage()
		{
			await navigation.PopToRootAsync(true);
		}


	}
}
