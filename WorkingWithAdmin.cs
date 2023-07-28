using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal class WorkingWithAdmin : IState
    {

        private readonly StateMachine _stateMachine;
        private readonly AppDB _db;
        private readonly Admin _admin;

        public WorkingWithAdmin(StateMachine stateMachine, AppDB db, Admin admin)
        {
            this._stateMachine = stateMachine;
            this._db = db;
            this._admin = admin;
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
                        _admin.ViewAllUsers(_db, (User)_admin);
                        break;
                    case 2:
                        Console.WriteLine("Введите ник пользователя у которого вы хотите посмотреть друзей ");
                        string nick = Convert.ToString(Console.ReadLine());
                        int idUsers = _db.FindIdUser(nick);
                        Console.WriteLine("Вот его список друзей: ");
                        _db.ViewUsersFriends((DefautUser)_db.FindUser(idUsers));
                        break;
                    case 3:
                        _admin.DeleteUsers(_db);
                        break;
                }
                Console.WriteLine(" ");
            } while (choice != 4);
            _stateMachine.SetState(new DataInitialization(_stateMachine, _db));
        }

        public void OnExit()
        {
            Console.WriteLine("До свидания админ!");
        }
    }     
}

