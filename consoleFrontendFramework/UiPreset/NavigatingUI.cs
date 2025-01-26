using consoleFrontendFramework.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleFrontendFramework.UiPreset
{
    public class NavigatingUI : IUI
    {
        string? header;
        string? error;
        IAction[] actions;

        public bool setActions (IAction[] actions)
        {
            try
            {
                this.actions = actions;
                return true;
            }
            catch { return false; }
        }
        public NavigatingUI(string? header)
        {
            this.header = header;
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
            for (int i=0; i<actions.Length; i++)
            {
                screen += $"{i+1}) {actions[i].GetName()}\n";
            }

            return screen;
        }

        IUI? IUI.input(string? input)
        {
            if (input == null || input == "") { return this; }

            int? actionNumber = null;
            try {actionNumber = int.Parse(input) - 1; } catch { }

            if (!actionNumber.HasValue)
            {
                error = "Input can only contain numbers\n\n";
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
