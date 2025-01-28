using consoleFrontendFramework.ActionPreset;
using consoleFrontendFramework.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_ttrpg_combat_manager.UI.customActions
{
    public class Confirm: NavigateTo
    {
        private Action<Type> action;
        private Type item;
        public Confirm(string name, IUI targetUi, Action<Type> action, Type item): base (name, targetUi)
        {
            this.action = action;
            this.item = item;
        }

        public override IUI? Run()
        {
            action(this.item);
            return base.Run();
        }
    }
}
