using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal class BuyTradeFactory : ITradeFactory
    {
        public AbstractTrade createTrade(bool fok, Bot b)
        {
            AbstractTrade ret = new BuyTrade(fok ? ITradeFactory.FOK : ITradeFactory.IOC, b);
            return ret;
        }
    }
}
