using consoleFrontendFramework.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleFrontendFramework.preset
{
    public class NavigatingUI : IUI
    {
        string? header;
        string? error;
        List<IAction> actions;
        public NavigatingUI(string? header, List<IAction> actions)
        {
            this.header = header;
            this.actions = actions;
        }
        string IUI.GetScreen()
        {
            string screen = "";

            if (header != null)
            {
                screen += header;
            }
            if (error != null)
            {
                screen += error;
            }
            foreach (IAction action in actions)
            {
                screen += action.GetName();
            }

            return screen;
        }

        IUI? IUI.input(string? input)
        {
            int? actionNumber = null;
            try { actionNumber = int.Parse(input); } catch { }

            if (actionNumber == null)
            {
                error = "Input can only contain naumbers";
                return null;
            }
            else
            {
                return actions[actionNumber.Value].Run();
            }
        }
    }
}
