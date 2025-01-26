using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleFrontendFramework.interfaces
{
    public interface IAction
    {
        string GetName ();
        IUI? Run ();
    }
}
