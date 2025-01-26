using consoleFrontendFramework.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleFrontendFramework.ActionPreset
{
    internal class NavigateTo: IAction
    {
        string name;
        IUI target;

        NavigateTo (string name, IUI returnUI)
        {
            this.name = name;
            this.target = returnUI;
        }

        string IAction.GetName()
        {
            return name;
        }

        IUI? IAction.Run()
        {
            return target;
        }
    }
}
