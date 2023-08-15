using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    public class Admin : User, IAdmin
    {
        public Admin(string nick)
        {
           
        }

        public User DeleteUsers(WorkingWhithDB db)
        {
            Console.WriteLine("Введите ник пользователя которого вы хотите удалить ");
            string nick = Convert.ToString(Console.ReadLine());
            int idUsers = db.FindIdUser(nick);
            db.CleanupAfterRemoval(idUsers);
            db.DeletingUser(db.FindUser(idUsers));
            return this;
        }

        public User ViewAllUsers(WorkingWhithDB db, User user)
        {
            db.CheckBD(user);
            return this;
        }

        public DefautUser ViewUsersFriends(WorkingWhithDB db)
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
