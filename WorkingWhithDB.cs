using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    /// <summary>
    /// Allows you to check if there is a user in the database, searches for a user in the database, looks at friends of a certain user.
    /// </summary>
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

        public bool CheckFrendsInList(DefautUser defautUser, User user) => defautUser.friendsUsers.Any(x => x.Nick == user.Nick);
        

        public User FindUser(int id)
        {
            if (appDBs.Any(x => x.Id == id))
                return appDBs.Find(x => x.Id == id);
            else return null;
        }

        public void CheckBD(Admin admin)
        {
            for (int i = 0; i < appDBs.Count; i++)
            {
                using (StreamWriter streamWriter = new StreamWriter("AllUsers.txt", false, Encoding.UTF8))
                {
                    streamWriter.Write(appDBs[i].Nick);
                }
                Console.WriteLine(appDBs[i].Nick);

            }
        }

        public void ViewUsersFriends(DefautUser defautUser)
        {
            for (int i = 0; i < defautUser.friendsUsers.Count; i++)
                Console.WriteLine(defautUser.friendsUsers[i].Nick);
        }

        public void DeletingUser(User user) => appDBs.Remove(user);

        public void CleanupAfterRemoval(int id) 
        { 
            for (int i = 0; i < appDBs.Count; i++)
            {
                if (appDBs[i] is DefautUser defautUser)
                {
                    if(CheckFrendsInList(defautUser, FindUser(id)))
                        defautUser.friendsUsers.Remove(FindUser(id));
                }
            }
        }
    }
}
