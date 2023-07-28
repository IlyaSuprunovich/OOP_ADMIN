using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal class DataInitialization : State, IState
    {

        private readonly StateMachine _stateMachine;
        private readonly AppDB _db;

        public DataInitialization(StateMachine stateMachine, AppDB db)
        {
            this._stateMachine = stateMachine;
            this._db = db;
        }

        public void OnEnter()
        {
            Console.WriteLine("Введите логин и пароль:");
        }

        public void OnTick()
        {
            string login = Convert.ToString(Console.ReadLine());
            string password = Convert.ToString(Console.ReadLine());
            _stateMachine.Login = login;
            _stateMachine.Password = password;

            _stateMachine.SetState(new DataChecking(_stateMachine, _db));
        }

        public void OnExit()
        {
            Console.WriteLine("Данные получены");
        }

       

        
    }
}
