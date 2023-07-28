using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal class DataChecking : IState
    {

        private readonly StateMachine _stateMachine;
        private readonly AppDB _db;
        

        public DataChecking(StateMachine stateMachine, AppDB db)
        {
            
            this._stateMachine = stateMachine;
            this._db = db;
        }

        public void OnEnter()
        {
            Console.WriteLine("Данные обрабатываются...");
        }

        public void OnTick()
        {
            if (_db.IsLoginAndPasswordExist(_stateMachine.Login, _stateMachine.Password) == true)
            {
                Console.WriteLine("Добро пожаловать " + _db.FindUser(_stateMachine.Login, _stateMachine.Password).Nick);
                _stateMachine.Id = _db.FindUser(_stateMachine.Login, _stateMachine.Password).Id;

                if (_db.FindUser(_stateMachine.Id) is DefautUser defautUser)
                    _stateMachine.SetState(new WorkingWhithDefaultUser(_stateMachine, _db, defautUser));
                
                else if (_db.FindUser(_stateMachine.Id) is Admin admin)
                    _stateMachine.SetState(new WorkingWithAdmin(_stateMachine, _db, admin));
                
            }
            else
            {
                Console.WriteLine("Неверный логин или пароль");
                _stateMachine.SetState(new DataInitialization(_stateMachine, _db));
            }
        }

        public void OnExit()
        {
            Console.WriteLine("Переходим к работе с интерфейсом");
        }

        

        
    }
}
