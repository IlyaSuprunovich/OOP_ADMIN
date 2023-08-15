using System;
using System.Collections.Generic;

namespace OOP_ADMIN
{
    internal class App
    { 
        public App()
        {
            
        }
        public void StartApp()
        {

            AppDB appDB = new AppDB();
            WorkingWhithDB db = new WorkingWhithDB(appDB);
            StateMachine stateMachine = new StateMachine(db);

            stateMachine.SetState<DataInitialization>();

            while (true)   
                stateMachine.Handle();
        }
    }
}
