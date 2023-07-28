using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal interface IPremitionService
    {
        bool IIsLoginAndPasswordExist(string login, string password);
        string IFindIdUser(string login, string password);
        bool IFindIdUser(string nick);

        User IFindUser(string login);

        User IFindNickUser(string nick);
        string ICheckBD();

        

    }
}
