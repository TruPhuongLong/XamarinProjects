using System;
using CustomerApp.src.redux.actions;
using CustomerApp.src.redux.reducers;

namespace CustomerApp.src.redux.store
{
    public interface IStore<T, M>
    {
		T State { get; }
		IReducer<T, M> Reducer { get; }
		void Constructor(IReducer<T, M> reducer, T initialState);
		void Dispath(IAction<M> action);
    }
}