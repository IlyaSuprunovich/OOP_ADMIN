using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal class DataInitialization : IState, IData<Data>
    {

        private readonly AppDB _db;
        private StateMachine _stateMachine;
        private  Data _data;

        public DataInitialization()
        {
            _db = new AppDB();
            _data = new Data();
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
            _data.Db = _db;
            _data.StateMachine = _stateMachine;
            _stateMachine.SetState<DataChecking, Data>(_data);
        }

        public void OnExit()
        {
            Console.WriteLine("Данные получены");
        }

        public void OnEnter(Data data)
        {
            this._stateMachine = data.StateMachine;
        }
    }
}
