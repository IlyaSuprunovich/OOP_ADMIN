using System;

namespace OOP_ADMIN
{
    internal class App
    {
        AppDB db = new AppDB();
        public App()
        {
            db = new AppDB();
        }



        public void StartApp()
        {
            while (true)
            {
                Console.WriteLine("Введите логин и пароль:");
                string login = Convert.ToString(Console.ReadLine());
                string password = Convert.ToString(Console.ReadLine());
                if (db.IIsLoginAndPasswordExist(login, password) == true)
                {
                    Console.WriteLine("Добро пожаловать " + db.IFindIdUser(login, password));

                    int choose;

                    if (db.IFindUser(login) is DefautUser)
                    {
                        DefautUser temp = new DefautUser(db.IFindUser(login).Nick)
                        {
                            Login = db.IFindUser(login).Login,
                            Nick = db.IFindUser(login).Nick,
                            Password = db.IFindUser(login).Password,
                            Id = db.IFindUser(login).Id
                        };

                        do
                        {
                            Console.WriteLine("Выберете, что вы хотите сделать\n1. Добавить друга\n2. Удалить друга\n3. Просмотр своих друзей\n4. Выйти из приложения");
                            choose = Convert.ToInt32(Console.ReadLine());

                            switch (choose)
                            {
                                case 1:
                                    Console.WriteLine("Введите ник друга");
                                    string nick = Convert.ToString(Console.ReadLine());
                                    if (db.IFindIdUser(nick) == true)
                                    {
                                        temp.IAddFriends(db.IFindNickUser(nick));
                                    }
                                    else Console.WriteLine("Такого пользователя не существует!");
                                    break;
                                case 2:
                                    Console.WriteLine("Введите ник друга");
                                    nick = Convert.ToString(Console.ReadLine());
                                    if (db.IFindIdUser(nick) == true)
                                    {
                                        temp.IDeletFriends(db.IFindNickUser(nick));
                                        Console.WriteLine($"Пользователь с ником {db.IFindNickUser(nick).Nick} удален из друзей!");
                                    }
                                    else Console.WriteLine("Такого пользователя не существует!");
                                    break;
                                case 3:
                                    if (temp.friendsUsers.Count > 0)
                                        for (int i = 0; i < temp.friendsUsers.Count; i++)
                                            Console.WriteLine(temp.friendsUsers[i].Nick);
                                    else Console.WriteLine("У вас нет друзей!");
                                    break;
                            }
                            Console.WriteLine(" ");
                        } while (choose != 4);

                    }
                    else
                    {
                        Admin temp = new Admin(db.IFindUser(login).Nick)
                        {
                            Login = db.IFindUser(login).Login,
                            Nick = db.IFindUser(login).Nick,
                            Password = db.IFindUser(login).Password,
                            Id = db.IFindUser(login).Id
                        };

                        do
                        {
                            Console.WriteLine("Выберете, что вы хотите сделать\n1. Посмотреть всех пользователей\n2. Посмотреть друзей конкретного пользователя\n3. Удалить пользователя\n4. Выйти из приложения");
                            choose = Convert.ToInt32(Console.ReadLine());

                            switch (choose)
                            {
                                case 1:
                                    temp.ViewAllUsers(db);
                                    break;
                                case 2:

                                    break;
                                case 3:

                                    break;
                            }
                            Console.WriteLine(" ");
                        } while (choose != 4);

                    }

                }
                else Console.WriteLine("Неверный логин или пароль");
            }
        }
    }
}
