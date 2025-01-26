using consoleFrontendFramework.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace consoleFrontendFramework.UiPreset
{
    public class ExitUI : IUI
    {
        static string header;
        string? error;
        IUI returnUi;
        public ExitUI(IUI returnUI)
        {
            this.returnUi = returnUI;
            header = "Closing application...\n";
        }
        string IUI.GetScreen()
        {
            string screen = "";

            screen += header;
            if (error != null)
            {
                screen += error;
            }

            return screen;
        }

        IUI? IUI.input(string? input)
        {
            try
            {
                int action = int.Parse(input);

                switch (action)
                {
                    case 1:
                        return null;
                    case 2:
                        return returnUi;
                    default:
                        error = "Input must be a number from the list.\n";
                        return this;
                }
            }
            catch 
            { 
                error = "Input can only contain numbers\n"; 
                return this;
            }
        }
    }
}
