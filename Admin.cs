using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    /// <summary>
    /// Contains functionality for viewing all users, viewing all user friends, deleting a user.
    /// </summary>
    public class Admin : User, IAdmin
    {
        public Admin(string nick)
        {
           
        }

        public User DeleteUsers(WorkWhithDB db)
        {
            Console.WriteLine("Введите ник пользователя которого вы хотите удалить ");
            string nick = Convert.ToString(Console.ReadLine());
            int idUsers = db.FindIdUser(nick);
            if (db.FindUser(idUsers) != this)
            {
                db.CleanupAfterRemoval(idUsers);
                db.DeletingUser(db.FindUser(idUsers));
            }
            else Console.WriteLine("Админа нельзя удалить!");
            return this;
        }

        public User ViewAllUsers(WorkWhithDB db, Admin admin)
        {
            db.CheckBD(admin);
            return this;
        }

        public DefautUser ViewUsersFriends(WorkWhithDB db)
        {
            Console.WriteLine("Введите ник пользователя у которого вы хотите посмотреть друзей ");
            string nick = Convert.ToString(Console.ReadLine());
            int idUsers = db.FindIdUser(nick);
            Console.WriteLine("Вот его список друзей: ");
            db.ViewUsersFriends((DefautUser)db.FindUser(idUsers));
            return (DefautUser)db.FindUser(idUsers);
        }
    }
}
