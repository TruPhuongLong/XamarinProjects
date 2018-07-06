using System;
using CustomerApp.src.redux.actions;

namespace CustomerApp.src.redux.reducers
{
    public interface IReducer<T>
    {
		T Exec(T state, IAction action);
    }
}
