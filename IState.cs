using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    public interface IState
    {
        void OnEnter();
        void OnTick();
        void OnExit();
    }
}
