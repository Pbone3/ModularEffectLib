using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModularEffectLib.Core.EventSystem
{
    internal class EventContainer<TDelegate>
    {
        public TDelegate Event;

        public void Subscribe(MethodInfo info)
        {
            if (!typeof(Delegate).IsAssignableFrom(typeof(TDelegate)))
                return;

            Delegate method = Delegate.CreateDelegate(typeof(TDelegate), info);
            MulticastDelegate evnt = (Event as MulticastDelegate);
        }
    }
}
