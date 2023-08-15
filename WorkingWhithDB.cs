using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    public class WorkWhithDB : AppDB, IPremitionService 
    {
        private readonly AppDB _db;

        public WorkWhithDB(AppDB db)
        {
            this._db = db;
        }

        public bool IsLoginAndPasswordExist(string login, string password) =>appDBs.Any(x => x.Login == login && x.Password == password);

        public User FindUser(string login, string password)
        {

            if (appDBs.Any(x => x.Login == login && x.Password == password))
            {

                int id = appDBs.FindIndex(x => x.Login == login && x.Password == password);
                return appDBs[id];
            }
            else return null;

        }

        public int FindIdUser(string nick)
        {
            if (appDBs.Any(x => x.Nick == nick))
            {
                int id = appDBs.FindIndex(x => x.Nick == nick);
                return appDBs[id].Id;
            }
            else return int.MinValue;
        }

        public bool CheckUserInDB(int id) => appDBs.Any(x => x.Id == id);

        public User FindUser(int id)
        {
            if (appDBs.Any(x => x.Id == id))
                return appDBs.Find(x => x.Id == id);
            else return null;
        }

        public void CheckBD(User user)
        {
            for (int i = 0; i < appDBs.Count; i++)
                if (user.Id != appDBs[i].Id)
                    Console.WriteLine(appDBs[i].Nick);

        }

        public void ViewUsersFriends(DefautUser defautUser)
        {
            for (int i = 0; i < defautUser.friendsUsers.Count; i++)
                Console.WriteLine(defautUser.friendsUsers[i].Nick);
        }

        public void DeletingUser(User user) => appDBs.Remove(user);

        public void CleanupAfterRemoval(int id) // Не бей за это...
        {
            for (int i = 0; i < appDBs.Count; i++)// Цикл для перебора всех юзеров
            {
                if (appDBs[i] is DefautUser defautUser)
                {
                    for (int j = 0; j < defautUser.friendsUsers.Count; j++) // Цикл для перебора всех друзей юзера
                    {
                        for (int z = 0; z < appDBs.Count; z++) // Цикл для сравнения друзей и всех возможных юзеров
                        {
                            if (defautUser.friendsUsers[j].Id == appDBs[z].Id)
                            {
                                defautUser.friendsUsers.RemoveAt(j);
                                break;
                            }

                        }
                    }
                }
            }
        }
    }
}
