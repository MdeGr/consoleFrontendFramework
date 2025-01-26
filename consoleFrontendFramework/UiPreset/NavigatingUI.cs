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
        IAction[] actions;
        public NavigatingUI(string? header, IAction[] actions)
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
            for (int i=0; 1<actions.Length; i++)
            {
                screen += $"{i+1}) {actions[i].GetName()}\n";
            }

            return screen;
        }

        IUI? IUI.input(string? input)
        {
            int? actionNumber = null;
            try { actionNumber = int.Parse(input); } catch { }

            if (actionNumber == null)
            {
                error = "Input can only contain naumbers\n\n";
                return this;
            }
            else
            {
                try
                {
                    return actions[actionNumber.Value].Run();
                }
                catch
                {
                    error = $"number cannot be bigger the {actions.Length}\n\n";
                    return this;
                }
            }
        }
    }
}
