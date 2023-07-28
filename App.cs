using System;

namespace OOP_ADMIN
{
    internal class App
    {
        AppDB db = new AppDB();
        StateMachine stateMachine = new StateMachine();
        public App()
        {
            db = new AppDB();
            stateMachine = new StateMachine();
        }



        public void StartApp()
        {
            while (true)
            {
                stateMachine.DataInitialization(out string login, out string password);
                if (db.IsLoginAndPasswordExist(login, password) == true)
                {
                    Console.WriteLine("Добро пожаловать " + db.IFindIdUser(login, password));

                    stateMachine.Greetings(login, password, out int id);

                    if (db.FindUser(id) is DefautUser defautUser)
                    {
                        int choice;
                        do
                        {
                            stateMachine.ChoiceMenuDefaultUser(out choice);
                            switch (choice)
                            {
                                case 1:
                                    stateMachine.WorkingWhithDefaultUserOne(id, defautUser);
                                    break;
                                case 2:
                                    stateMachine.WorkingWhithDefaultUserTwo(id, defautUser);
                                    break;
                                case 3:
                                    stateMachine.WorkingWhithDefaultUserThree(defautUser);
                                    break;
                            }
                            Console.WriteLine(" ");
                        } while (choice != 4);

                    }
                    else if(db.FindUser(id) is Admin admin)
                    {
                        int choice;
                        do
                        {
                            stateMachine.ChoiceMenuAdmin(out choice);
                            switch (choice)
                            {
                                case 1:
                                    admin.ViewAllUsers(db, (User)admin);
                                   // stateMachine.WorkingWhithAdminOne(admin);
                                    break;
                                case 2:
                                     admin.ViewUsersFriends(db);
                                   // stateMachine.WorkingWhithAdminTwo(admin, db);
                                    break;
                                case 3:
                                     admin.DeleteUsers(db);
                                   // stateMachine.WorkingWhithAdminThree(admin);

                                    break;
                            }
                            Console.WriteLine(" ");
                        } while (choice != 4);

                    }

                }
                else Console.WriteLine("Неверный логин или пароль");
            }
        }
    }
}
