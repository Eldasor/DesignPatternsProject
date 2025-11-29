using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // this should decide whether a stock should be bought or not
    // the strategy not only decides on a trade, but also helps build it
    internal interface IStrategy
    {
        // the parameter is for assigning a ticker
        public AbstractTrade? decide(String s = "");
        public String describe();
    }
}
