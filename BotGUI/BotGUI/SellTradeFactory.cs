using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal class SellTradeFactory : ITradeFactory
    {
        public AbstractTrade createTrade(bool fok, Bot b)
        {
            AbstractTrade ret = new SellTrade(fok ? ITradeFactory.FOK : ITradeFactory.IOC, b);
            return ret;
        }
    }
}
