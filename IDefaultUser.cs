using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal interface IDefaultUser
    {
        User IAddFriends(User user);
        User IDeletFriends(User user);
    }
}
