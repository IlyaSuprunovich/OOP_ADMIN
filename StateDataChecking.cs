using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_ADMIN
{
    /// <summary>
    /// Checks the entered data and determines the type of user.
    /// </summary>
    internal class StateDataChecking : IState, IData<DataForStateDataChecking>
    {

        private StateMachine _stateMachine;
        private DataForStateDataChecking _data;
        private DataForStateWorkingWhithDefaultUser _dataDefaultUser;
        private DataForStateWorkingWhithAdmin _dataAdmin;
        private WorkerWhithDB _db;
        
        public StateDataChecking(StateMachine stateMachine, WorkerWhithDB db)
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
            if (_db.IsLoginAndPasswordExist(_data.Login, _data.Password) == true)
            {
                Console.WriteLine("Добро пожаловать " + _db.FindUser(_data.Login, _data.Password).Nick);
                _data.Id = _db.FindUser(_data.Login, _data.Password).Id;

                if (_db.FindUser(_data.Id) is DefautUser defautUser)
                {
                    _dataDefaultUser.DefautUser = defautUser;
                   
                    _stateMachine.SetState<StateWorkingWhithDefaultUser, DataForStateWorkingWhithDefaultUser>(_dataDefaultUser);
                }

                else if (_db.FindUser(_data.Id) is Admin admin)
                {
                    _dataAdmin.Admin = admin;
                    _stateMachine.SetState<StateWorkingWithAdmin, DataForStateWorkingWhithAdmin>(_dataAdmin);
                }

            }
            else
            {
                Console.WriteLine("Неверный логин или пароль");
                _stateMachine.SetState<StateDataInitialization>();
            }
        }

        public void OnExit()
        {
            Console.WriteLine("Идем дальше!");
        }

        public void OnEnter(DataForStateDataChecking data)
        {
            _data.Login = data.Login;
            _data.Password = data.Password;
        }
    }
}
