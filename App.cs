using System;
using System.Collections.Generic;

namespace OOP_ADMIN
{
    /// <summary>
    /// Starts the state machine.
    /// </summary>
    internal class App
    { 
        public App()
        {
            
        }
        public void StartApp()
        {

            AppDB appDB = new AppDB();
            WorkWhithDB db = new WorkWhithDB(appDB);
            StateMachine stateMachine = new StateMachine(db);

            stateMachine.SetState<DataInitialization>();

            while (true)   
                stateMachine.Handle();
        }
    }
}
