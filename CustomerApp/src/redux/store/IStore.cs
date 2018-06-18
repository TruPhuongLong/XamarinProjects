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


/*
        private _state: T;
constructor(
private reducer: Reducer<T>, initialState: T
){
this._state = initialState;
}
    getState() : T { return this._state;
}
    dispatch(action: Action) : void {
this._state = this.reducer(this._state, action);
}
*/
