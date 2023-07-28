using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal class DefautUser : User, IDefaultUser
    {
        public List<User> friendsUsers = new List<User>();

        public DefautUser(string nick)
        {
          
        }

        public User AddFriends(User user)
        {
            if (user is DefautUser)
            {
                friendsUsers.Add(user);
                Console.WriteLine($"Теперь пользователь с ником {user.Nick} ваш друг!");
            }
            else Console.WriteLine("Админ не может быть другом!");
            return this;
        }

        public User DeletFriends(User user)
        {
            friendsUsers.Remove(user);
            return this;
        }
        
        
    }
}
