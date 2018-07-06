using System;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.reducers;

namespace CustomerApp.src.redux.store
{
    public interface IStore<T>
    {
		T State { get; }
		IReducer<T> Reducer { get; }
		void Constructor(IReducer<T> reducer, T initialState);
		void Dispath(IAction action);
    }
}