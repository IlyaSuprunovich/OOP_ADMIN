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
            WorkerWhithDB db = new WorkerWhithDB(appDB);
            StateMachine stateMachine = new StateMachine(db);

            stateMachine.SetState<StateDataInitialization>();

            while (true)   
                stateMachine.Handle();
        }
    }
}
