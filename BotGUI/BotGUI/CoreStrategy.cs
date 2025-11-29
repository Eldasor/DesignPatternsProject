using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal class CoreStrategy : IStrategy
    {
        bool buy;
        bool fok;
        Bot receiver;

        public CoreStrategy(bool b, bool f, Bot bot)
        {
            buy = b;
            fok = f;
            receiver = bot;
        }

        public AbstractTrade? decide(String s = "")
        {
            ITradeFactory factory = ITradeFactory.makeFactory(buy);
            AbstractTrade trade = factory.createTrade(fok, receiver);
            trade.setTicker(s);
            return trade;
        }

        public String describe()
        {
            String ret = (buy) ? "Buy, " : "Sell, ";
            ret += (fok) ? "Fill or Kill\n" : "Immediate or Cancel\n";
            return ret;
        }
    }
}
