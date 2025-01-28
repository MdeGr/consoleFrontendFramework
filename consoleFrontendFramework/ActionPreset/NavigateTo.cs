using consoleFrontendFramework.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleFrontendFramework.ActionPreset
{
    public class NavigateTo: IAction
    {
        string name;
        IUI target;

        public NavigateTo (string name, IUI returnUI)
        {
            this.name = name;
            this.target = returnUI;
        }

        string IAction.GetName()
        {
            return name;
        }

        public virtual IUI? Run()
        {
            return target;
        }
    }
}
