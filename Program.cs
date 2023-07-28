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
            /*App app = new App();
            app.StartApp();
            Console.ReadLine();*/

            StateMachine stateMachine = new StateMachine();
            while (true)
            {
                stateMachine.Handle();
            }

            
            
        }
    }
}
