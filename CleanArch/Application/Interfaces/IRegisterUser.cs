using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudInMemory.Application.Interfaces
{
    public interface IRegisterUser
    {
        void Execute(string userName);
    }
}
