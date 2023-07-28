using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    class Admin : User, IAdmin
    {
        public Admin(string nick)
        {
           
        }

        public User DeleteUsers(AppDB db)
        {
            return this;
        }

        public User ViewAllUsers(AppDB db)
        {
            db.ICheckBD();
            return this;
        }

        public User ViewUsersFriends(AppDB db)
        {
            Console.WriteLine("Введите ник пользователя у которого вы хотите посмотреть");
            string nick = Convert.ToString(Console.ReadLine());
            
            return this;
        }
    }
}
