using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    /// <summary>
    /// Interface for working whith Admin.
    /// </summary>
    internal interface IAdmin
    {
        User ViewAllUsers(WorkWhithDB db, Admin admin);
        DefautUser ViewUsersFriends(WorkWhithDB db);
        User DeleteUsers(WorkWhithDB db);
    }
}
