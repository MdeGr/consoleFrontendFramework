using consoleFrontendFramework.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleFrontendFramework.preset
{
    public class UIManger
    {
        bool Running;
        bool exiting;
        IUI? ui;

        public UIManger (IUI? openingUi)
        {
            this.ui = openingUi;
        }

        public string runCycle (string? input)
        {
            IUI newUi = ui.input(input);
            if (newUi == null) {Running = false;}
            return ui.GetScreen();
        }
    }
}
