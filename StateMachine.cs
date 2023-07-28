using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
   internal class StateMachine
    {
        AppDB db;
        private List<IState> _states = new List<IState>();
        private IState _currentState;
        public string Login { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }

        

        public StateMachine(/*State stateA, State stateB, State stateC, State stateD*/)
        {
            db = new AppDB();
            /*_states.Add(stateA);
            _states.Add(stateB);
            _states.Add(stateC);
            _states.Add(stateD);*/
            _currentState = new DataInitialization(this, db);
        }


        public void SetState(IState state)
        {
            if(_currentState != null)
                _currentState.OnExit();
            _currentState = state;
            
        }

        public void Handle()
        {
            _currentState.OnEnter();
            _currentState.OnTick();
        }
    }




}
