using consoleFrontendFramework.interfaces;
using consoleFrontendFramework.UiPreset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace consoleFrontendFramework.ActionPreset
{
    internal class ExitAction : IAction
    {
        IUI returnUI;
        public ExitAction(IUI returnUI)
        {
            this.returnUI = returnUI;
        }
        string IAction.GetName()
        {
            return "Exit Aplication";
        }

        IUI? IAction.Run()
        {
            return new ExitUI(returnUI);
        }
    }
}
