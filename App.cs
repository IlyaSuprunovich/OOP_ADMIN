using System;
using System.Collections.Generic;

namespace OOP_ADMIN
{
    internal class App
    {
        AppDB db;

        //public List<StateMachine> states;

        //StateMachine stateMachine = new StateMachine(db);
        public App()
        {
            db = new AppDB();
            // stateMachine = new StateMachine(db);


        }



        public void StartApp()
        {
            string login;
            do
            {
                Console.WriteLine("Введите логин и пароль:");
                login = Convert.ToString(Console.ReadLine());
                string password = Convert.ToString(Console.ReadLine());

                if (db.IsLoginAndPasswordExist(login, password) == true)
                {


                    Console.WriteLine("Добро пожаловать " + db.FindUser(login, password).Nick);

                    int id = db.FindUser(login, password).Id;

                    if (db.FindUser(id) is DefautUser defautUser)
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
                                    int idFriends = db.FindIdUser(nick);
                                    if (db.CheckUserInDB(idFriends) == true && db.FindUser(id) != db.FindUser(idFriends))
                                    {
                                        defautUser.AddFriends(db.FindUser(idFriends));
                                    }
                                    else Console.WriteLine("Такого пользователя не существует!");
                                    break;
                                case 2:
                                    Console.WriteLine("Введите ник друга");
                                    nick = Convert.ToString(Console.ReadLine());
                                    idFriends = db.FindIdUser(nick);
                                    if (db.CheckUserInDB(idFriends) == true)
                                    {
                                        defautUser.DeletFriends(db.FindUser(idFriends));
                                        Console.WriteLine($"Пользователь с ником {db.FindUser(idFriends).Nick} удален из друзей!");
                                    }
                                    else Console.WriteLine("Такого пользователя не существует!");
                                    break;
                                case 3:
                                    if (defautUser.friendsUsers.Count > 0)
                                        for (int i = 0; i < defautUser.friendsUsers.Count; i++)
                                            Console.WriteLine(defautUser.friendsUsers[i].Nick);
                                    else Console.WriteLine("У вас нет друзей!");
                                    break;
                            }
                            Console.WriteLine(" ");
                        } while (choice != 4);

                    }
                    else if (db.FindUser(id) is Admin admin)
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
                                    admin.ViewAllUsers(db, (User)admin);
                                    break;
                                case 2:
                                    admin.ViewUsersFriends(db);
                                    break;
                                case 3:
                                    admin.DeleteUsers(db);
                                    break;
                            }
                            Console.WriteLine(" ");
                        } while (choice != 4);

                    }

                }
                else Console.WriteLine("Неверный логин или пароль");



            } while (login != "!");
        }
    }
}
