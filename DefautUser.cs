﻿using System;
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

        public User IAddFriends(User user)
        {
            if (user is DefautUser)
            {
                friendsUsers.Add(user);
                Console.WriteLine($"Теперь пользователь с ником {user.Nick} ваш друг!");
            }
            else Console.WriteLine("Админ не может быть другом!");
            return this;
        }

        public User IDeletFriends(User user)
        {
            friendsUsers.Remove(user);
            return this;
        }
        
        public User IGetListFriends(AppDB db, string nick)
        {
            nick = db.IFindNickUser(nick).Nick;

            for(int i = 0; i < friendsUsers.Count; i++)
            {

                Console.WriteLine(friendsUsers[i]); 
                
            }
            return this;
                
        }
    }
}