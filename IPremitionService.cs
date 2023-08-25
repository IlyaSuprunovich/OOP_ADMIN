using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    public interface IPremitionService
    {
        bool IsLoginAndPasswordExist(string login, string password);

        User FindUser(string login, string password); 

        User FindUser(int id);

        int FindIdUser(string nick);

        bool CheckUserInDB(int id); 

        void CheckBD(Admin admin);

        bool CheckFrendsInList(DefautUser defautUser, User user);

        void ViewUsersFriends(DefautUser defautUser);

        void DeletingUser(User user);

        void CleanupAfterRemoval(int id);




    }
}
