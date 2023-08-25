using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal class WorkingWhithDefaultUser : IState, IData<DataForStateWorkingWhithDefaultUser>
    {
        private readonly StateMachine _stateMachine;
        private WorkWhithDB _db;
        private DefautUser _defautUser;
        private DataForStateWorkingWhithDefaultUser _data;

        public  WorkingWhithDefaultUser(StateMachine stateMachine, WorkWhithDB db)
        {
            this._stateMachine = stateMachine;
            this._db = db;
        }

        public void OnEnter()
        {
            Console.WriteLine("Работа с пользователем");
        }

        public void OnTick()
        {
            int choice;
            do
            {
                Console.WriteLine("Выберете, что вы хотите сделать\n" +
                                 "1. Добавить друга\n" +
                                 "2. Удалить друга\n" +
                                 "3. Просмотр своих друзей\n" +
                                 "4. Выйти из приложения");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите ник друга");
                        string nick = Convert.ToString(Console.ReadLine());
                        int idFriends = _db.FindIdUser(nick);
                        if (_db.CheckUserInDB(idFriends) == true && _db.FindUser(idFriends) != this._defautUser && !_db.CheckFrendsInList(_defautUser, _db.FindUser(idFriends)))
                                _defautUser.AddFriends(_db.FindUser(idFriends));   
                        else Console.WriteLine("Невозможно добавить в друзья!");
                        break;
                    case 2:
                        Console.WriteLine("Введите ник друга");
                        nick = Convert.ToString(Console.ReadLine());
                        idFriends = _db.FindIdUser(nick);
                        if (_db.CheckFrendsInList(_defautUser, _db.FindUser(idFriends)))
                        {
                            _defautUser.DeletFriends(_db.FindUser(idFriends));
                            Console.WriteLine($"Пользователь с ником {_db.FindUser(idFriends).Nick} удален из друзей!");
                        }
                        break;
                    case 3:
                        if (_defautUser.friendsUsers.Count > 0)
                            for (int i = 0; i < _defautUser.friendsUsers.Count; i++)
                                Console.WriteLine(_defautUser.friendsUsers[i].Nick);
                        else Console.WriteLine("У вас нет друзей!");
                        break;
                }
                Console.WriteLine(" ");
            } while (choice != 4);
           _stateMachine.SetState<DataInitialization>( );
        }

        public void OnExit()
        {
             Console.WriteLine("До встречи!");
        }

        public void OnEnter(DataForStateWorkingWhithDefaultUser data)
        {
            this._defautUser = data.DefautUser;
        }
    }
}
