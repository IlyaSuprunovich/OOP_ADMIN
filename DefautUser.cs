using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    /// <summary>
    /// Contains functionality for adding a friend, deleting a friend.
    /// </summary>
    public class DefautUser : User, IDefaultUser
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
                using (StreamWriter streamWriter = new StreamWriter($"{this.Nick}FriendList.txt", false, UTF8Encoding.UTF8))     
                    streamWriter.WriteLine(user.Nick);
            }
            else Console.WriteLine("Админ не может быть другом!");
            return this;
        }

        public User DeletFriends(User user)
        {
            friendsUsers.Remove(user);
            Console.WriteLine($"Пользователь с ником {user.Nick} удален из друзей!");
            using (StreamWriter streamWriter = new StreamWriter($"{this.Nick}FriendList.txt", false, UTF8Encoding.UTF8))
                for (int j = 0; j < this.friendsUsers.Count; j++)
                    streamWriter.WriteLine(this.friendsUsers[j].Nick);
            return this;
        }

        
    }
}
