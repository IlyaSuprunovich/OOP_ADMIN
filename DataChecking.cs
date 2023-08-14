using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_ADMIN
{
    internal class DataChecking : IState, IData<Data>
    {

        private StateMachine _stateMachine;
        private Data _data;
        private AppDB _db;
        
        public DataChecking()
        {

        }

        public void OnEnter()
        {
            Console.WriteLine("Данные обрабатываются...");
        }

        public void OnTick()
        {
            OnEnter(_data);
            if (_db.IsLoginAndPasswordExist(_data.Login, _data.Password) == true)
            {
                Console.WriteLine("Добро пожаловать " + _db.FindUser(_data.Login, _data.Password).Nick);
                _data.Id = _db.FindUser(_data.Login, _data.Password).Id;

                if (_db.FindUser(_data.Id) is DefautUser defautUser)
                {
                    _data.DefautUser = defautUser;
                    _stateMachine.SetState<WorkingWhithDefaultUser, Data>(_data);
                }

                else if (_db.FindUser(_data.Id) is Admin admin)
                {
                    _data.Admin = admin;
                    _stateMachine.SetState<WorkingWithAdmin, Data>(_data);
                }

            }
            else
            {
                Console.WriteLine("Неверный логин или пароль");
                _stateMachine.SetState<DataInitialization, Data>(_data);
            }
        }

        public void OnExit()
        {
            Console.WriteLine("Переходим к работе с интерфейсом");
        }

        public void OnEnter(Data data)
        {
            _data = data; 
            _db = data.Db;
            _data.Login = data.Login;
            _data.Password = data.Password;
            _stateMachine = data.StateMachine;
        }
    }
}
