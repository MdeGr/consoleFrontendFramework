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
        private string? header;
        private string? error;
        public IAction[] actions;

        public NavigatingUI(string? header)
        {
            this.header = header;
        }
        public virtual string GetScreen()
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
