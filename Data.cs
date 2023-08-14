using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    public struct Data : IStateData
    {
        public int Id;
        public string Login;
        public string Password;
        public StateMachine StateMachine;
        public AppDB Db;
        public DefautUser DefautUser;
        public Admin Admin;
    }
}
