using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    public interface IData<TData> where TData : IStateData
    {
        void OnEnter(TData data);
    }
}
