using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // listener for callbacks - GUI updater will also piggyback on this
    internal interface IBackListener
    {
        // the boolean is for deleting on a callback
        bool back();
    }
}
