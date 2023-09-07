using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    /// <summary>
    /// Data entry from the user.
    /// </summary>
    internal class StateDataInitialization : IState, IData<DataForStateDataInitialization>
    {

        private readonly StateMachine _stateMachine;
        private DataForStateDataChecking _data;

        public StateDataInitialization(StateMachine stateMachine)
        {
            this._stateMachine = stateMachine;
            _data = new DataForStateDataChecking();
        }

        public void OnEnter()
        {
            Console.WriteLine("Введите логин и пароль:");
        }

        public void OnTick()
        {
            string login = Convert.ToString(Console.ReadLine());
            string password = Convert.ToString(Console.ReadLine());
            _data.Login = login;
            _data.Password = password; 
            _stateMachine.SetState<StateDataChecking, DataForStateDataChecking>((_data));
        }

        public void OnExit()
        {
            Console.WriteLine("Данные получены");
        }

        public void OnEnter(DataForStateDataInitialization data)
        {
            
        }
    }
}
