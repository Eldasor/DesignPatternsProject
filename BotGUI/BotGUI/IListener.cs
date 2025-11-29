using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // generic listener interface - allows for flow control on specific things
    // for both updating bot on time tick updates and GUI updates after
    internal interface IListener
    {
        void notify();
    }
}
