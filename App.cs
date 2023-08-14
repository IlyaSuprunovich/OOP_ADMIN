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
            Data data = new Data
            {
                StateMachine = stateMachine
            };

            stateMachine.SetState<DataInitialization, Data>(data);

            while (true)   
                stateMachine.Handle();
        }
    }
}
