using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal class AppDB : IPremitionService
    {
        private readonly List<User> appDBs;


        public AppDB()
        {
            appDBs = new List<User>()
            {
                new DefautUser("Ilja")
                {
                    Nick = "Ilja",
                    Id = 0,
                    Password = "qwerty",
                    Login = "ilja2004",
                    
                },

                new DefautUser("Mathey")
                {
                    Nick = "Mathey",
                    Id = 1,
                    Password = "QWERTY",
                    Login = "mathey2002",

                },

                new DefautUser("Vlad")
                {
                    Nick = "Vlad",
                    Id = 2,
                    Password = "123456",
                    Login = "vlad2005",
                    
                },

                new DefautUser("Nik")
                {
                    Nick = "Nik",
                    Id = 3,
                    Password = "!@#$%^",
                    Login = "nik2005",
                   
                },

                new Admin("Artom")
                {
                    Nick = "Artom",
                    Id = 4,
                    Password = "asdfg",
                    Login = "artom1999",
                  
                },
            };


        }
        public bool IIsLoginAndPasswordExist(string login, string password) => appDBs.Any(x => x.Login == login && x.Password == password);

        public string IFindIdUser(string login, string password)
        {

            if (appDBs.Any(x => x.Login == login && x.Password == password))
            {

                int id = appDBs.FindIndex(x => x.Login == login && x.Password == password);
                
                return appDBs[id].Nick;
            }
            else return null;
            
        }

        public bool IFindIdUser(string nick) => appDBs.Any(x => x.Nick == nick);

        public User IFindUser(string login)
        {
            if (appDBs.Any(x => x.Login == login))
            {

                int id = appDBs.FindIndex(x => x.Login == login);

                return appDBs[id];
            }
            else return null;
        }

        public User IFindNickUser(string nick)
        {
            if (appDBs.Any(x => x.Nick == nick))
            {

                int id = appDBs.FindIndex(x => x.Nick == nick);

                return appDBs[id];
            }
            else return null;
        }

        public string ICheckBD()
        {
            for (int i = 0; i < appDBs.Count; i++)
            {
                Console.WriteLine(appDBs[i].Nick);
                
            }

            return appDBs[0].Nick;
        }

       

       

    }
}
