using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    /// <summary>
    /// database simulation.
    /// </summary>
    public class AppDB
    {
        protected readonly List<User> appDBs;


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
                    Login = "vlad2002",

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
    }
}
