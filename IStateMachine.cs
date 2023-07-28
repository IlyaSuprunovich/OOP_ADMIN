using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal interface IStateMachine 
    {
        void DataInitialization(out string login, out string password);
        void Greetings(string login, string password, out int id);
        void ChoiceMenuDefaultUser(out int choice);
        void WorkingWhithDefaultUserOne(int id, DefautUser defautUser);
        void WorkingWhithDefaultUserTwo(int id, DefautUser defautUser);
        void WorkingWhithDefaultUserThree(DefautUser defautUser);
        void ChoiceMenuAdmin(out int choice);
        void WorkingWhithAdminOne(Admin admin);
        void WorkingWhithAdminTwo(Admin admin, AppDB dB);
        void WorkingWhithAdminThree(Admin admin);
    }
}
