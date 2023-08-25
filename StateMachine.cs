using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    /// <summary>
    /// Architecture for working with states.
    /// </summary>
    public class StateMachine
    {
        private readonly Dictionary<Type,IState> _states = new Dictionary<Type, IState>(5);
        private IState _currentState;

        public StateMachine(WorkWhithDB db )
        {
            
            DataInitialization dataInitialization = new DataInitialization(this);
            DataChecking dataChecking = new DataChecking(this, db);
            WorkingWhithDefaultUser workingWhithDefaultUser = new WorkingWhithDefaultUser(this, db);
            WorkingWithAdmin workingWithAdmin = new WorkingWithAdmin(this, db);
            _states.Add(dataInitialization.GetType(), dataInitialization);
            _states.Add(dataChecking.GetType(), dataChecking);
            _states.Add(workingWhithDefaultUser.GetType(), workingWhithDefaultUser);
            _states.Add(workingWithAdmin.GetType(), workingWithAdmin);
        }


        public void SetState<TState>() where TState : class, IState
        {
             _currentState?.OnExit();

            _currentState = _states[typeof(TState)];
            _currentState.OnEnter();
            
        }

        public void SetState<TState, TData>(TData data)
            where TState : class, IState
            where TData : IStateData
        {
            if (_currentState != null)
                _currentState.OnExit();

            _currentState = _states[typeof(TState)];


            if (_currentState is IData<TData> paramsState)
            {
                paramsState?.OnEnter(data);
            }
            else
            {
                
                throw new Exception("Not available type");
            }

            _currentState.OnEnter();

        }

        public void Handle()
        {
            _currentState?.OnTick();
        }
    }




}
