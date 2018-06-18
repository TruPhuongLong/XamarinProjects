using System;
using CustomerApp.src.redux.actions;

namespace CustomerApp.src.redux.reducers
{
    public interface IReducer<T, M>
    {
		T Exec(T state, IAction<M> action);
    }
}
