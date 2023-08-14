using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            app.StartApp();
            Console.ReadLine();



            /* DataInitialization a = new DataInitialization(db);
             DataChecking b = new DataChecking(db);
             WorkingWhithDefaultUser c = new WorkingWhithDefaultUser(db, defautUser);
             WorkingWithAdmin d = new WorkingWithAdmin(db, admin); 

             StateMachine stateMachine = new StateMachine(a, b, c, d);
             while (true)
             {
                 stateMachine.Handle();
             }
 */


        }
    }
}
