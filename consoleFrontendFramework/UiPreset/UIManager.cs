using consoleFrontendFramework.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleFrontendFramework.UiPreset
{
    public class UIManager
    {
        bool Running;
        IUI? ui;

        public bool GetRunning()
        {
            return Running;
        }

        public UIManager (IUI? openingUi)
        {
            this.ui = openingUi;
            Running = true;
        }

        public string RunCycle (string? input)
        {
            IUI newUi = ui.input(input);
            if (newUi == null) 
            { 
                Running = false;
                return "";
            }
            else
            {
                ui = newUi;
                return ui.GetScreen();
            }
        }
    }
}
