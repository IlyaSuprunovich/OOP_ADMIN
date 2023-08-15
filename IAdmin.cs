using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal interface IAdmin
    {
        User ViewAllUsers(WorkingWhithDB db, User user);
        DefautUser ViewUsersFriends(WorkingWhithDB db);
        User DeleteUsers(WorkingWhithDB db);
    }
}
