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
            StateMachine stateMachine = new StateMachine();

            stateMachine.SetState<DataInitialization>();

            while (true)   
                stateMachine.Handle();
        }
    }
}
