using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // this designates a strategy that "kills" itself
    // in other words, when it succeeds at creating a valid trade
    // it will then be deleted from the bot's strategies
    // this is basically a "do once" strategy decoration

    // note that the strategy will kill itself on a valid trade
    // by only definition - not on a successful trade by market!
    // that is, if it is a valid fill-or-kill request construction
    // but the market is unable to fill it, that still counts
    // as a valid trade request and the strategy will still delete!
    // that's intended behavior!
    internal class KillDetail : AbstractStrategyDetail
    {
        public KillDetail(IStrategy s) : base(s) { }

        public override AbstractTrade? decide(String s = "")
        {
            AbstractTrade? trade = core.decide(s);
            if (trade == null)
                return null;
            trade.setKill(true);
            return trade;
        }
        public override string describe()
        {
            return core.describe() + "Do only once\n";
        }
    }
}
