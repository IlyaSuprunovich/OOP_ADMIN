using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
   internal class StateMachine : IStateMachine
    {
        AppDB db = new AppDB();
        public StateMachine()
        {
            db = new AppDB();
        }

        public void DataInitialization(out string login, out string password)
        {
            Console.WriteLine("Введите логин и пароль:");
            login = Convert.ToString(Console.ReadLine());
            password = Convert.ToString(Console.ReadLine());
        }

        public void Greetings(string login, string password, out int id)
        {
            Console.WriteLine("Добро пожаловать " + db.FindUser(login, password).Nick);

            id = db.FindUser(login, password).Id;
        }

        public void ChoiceMenuDefaultUser(out int choice)
        {
            Console.WriteLine("Выберете, что вы хотите сделать\n" +
                                             "1. Добавить друга\n" +
                                             "2. Удалить друга\n" +
                                             "3. Просмотр своих друзей\n" +
                                             "4. Выйти из приложения");
            choice = Convert.ToInt32(Console.ReadLine());
        }

        public void WorkingWhithDefaultUserOne(int id, DefautUser defautUser)
        {
            Console.WriteLine("Введите ник друга");
            string nick = Convert.ToString(Console.ReadLine());
            int idFriends = db.FindIdUser(nick);
            if (db.CheckUserInDB(idFriends) == true && db.FindUser(id) != db.FindUser(idFriends))
            {
                defautUser.AddFriends(db.FindUser(idFriends));
            }
            else Console.WriteLine("Такого пользователя не существует!");
        }

        public void WorkingWhithDefaultUserTwo(int id, DefautUser defautUser)
        {
            Console.WriteLine("Введите ник друга");
            string nick = Convert.ToString(Console.ReadLine());
            int idFriends = db.FindIdUser(nick);
            if (db.CheckUserInDB(idFriends) == true)
            {
                defautUser.DeletFriends(db.FindUser(idFriends));
                Console.WriteLine($"Пользователь с ником {db.FindUser(idFriends).Nick} удален из друзей!");
            }
            else Console.WriteLine("Такого пользователя не существует!");
        }

        public void WorkingWhithDefaultUserThree(DefautUser defautUser)
        {
            if (defautUser.friendsUsers.Count > 0)
                for (int i = 0; i < defautUser.friendsUsers.Count; i++)
                    Console.WriteLine(defautUser.friendsUsers[i].Nick);
            else Console.WriteLine("У вас нет друзей!");
        }

        public void ChoiceMenuAdmin(out int choice)
        {
            Console.WriteLine("Выберете, что вы хотите сделать\n" +
                              "1. Посмотреть всех пользователей\n" +
                              "2. Посмотреть друзей конкретного пользователя\n" +
                              "3. Удалить пользователя\n" +
                              "4. Выйти из приложения");
            choice = Convert.ToInt32(Console.ReadLine());
        }

        public void WorkingWhithAdminOne(Admin admin)
        {
            admin.ViewAllUsers(db, (User)admin);
        }

        public void WorkingWhithAdminTwo(Admin admin, AppDB dB)
        {
            admin.ViewUsersFriends(db);
        }

        public void WorkingWhithAdminThree(Admin admin)
        {
            admin.DeleteUsers(db);
        }
    }


}
