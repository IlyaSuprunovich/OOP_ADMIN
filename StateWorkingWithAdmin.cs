﻿using System;

namespace OOP_ADMIN
{
    /// <summary>
    /// Statuses for working with the admin.
    /// </summary>
    internal class StateWorkingWithAdmin : IState, IData<DataForStateWorkingWhithAdmin>
    {

        private readonly StateMachine _stateMachine;
        private  WorkerWhithDB _db;
        private Admin _admin;
        

        public StateWorkingWithAdmin(StateMachine stateMachine, WorkerWhithDB db)
        {
            this._stateMachine = stateMachine;
            this._db = db;
        }

        public void OnEnter()
        {
            Console.WriteLine("Работа с админом");
        }

        public void OnTick()
        {
            int choice;
            do
            {
                Console.WriteLine("Выберете, что вы хотите сделать\n" +
                  "1. Посмотреть всех пользователей\n" +
                  "2. Посмотреть друзей конкретного пользователя\n" +
                  "3. Удалить пользователя\n" +
                  "4. Выйти из приложения");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        _admin.ViewAllUsers(_db, _admin);
                        break;
                    case 2:
                        Console.WriteLine("Введите ник пользователя у которого вы хотите посмотреть друзей ");
                        string nick = Convert.ToString(Console.ReadLine());
                        int idUsers = _db.FindIdUser(nick);
                        if (_db.FindUser(idUsers) != _admin)
                        {
                            Console.WriteLine("Вот его список друзей: ");
                            _db.ViewUsersFriends((DefautUser)_db.FindUser(idUsers));
                        }
                        else Console.WriteLine("У админа нельзя смотреть друзей!");
                        break;
                    case 3:
                        _admin.DeleteUsers(_db);
                        break;
                }
                Console.WriteLine(" ");
            } while (choice != 4);
            _stateMachine.SetState<StateDataInitialization>();
        }

        public void OnExit()
        {
            Console.WriteLine("До свидания админ!");
        }

        public void OnEnter(DataForStateWorkingWhithAdmin data)
        {
            this._admin = data.Admin;    
        }
    }
}

