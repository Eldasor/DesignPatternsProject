using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // this makes a decision to make a trade when the last seen
    // price relative to the cost basis of held shares is high
    // or low enough. while relative to the cost basis, this strategy
    // is still based in absolute value. i.e. if the held shares have
    // changed $X more than $Y cost basis
    // this strategy only makes sense for shares already owned
    internal class CostBasisDetail : AbstractStrategyDetail
    {
        float val;
        bool reverse; // if below, not above
        public CostBasisDetail(IStrategy s, float v, bool b) : base(s)
        {
            val = v;
            reverse = b;
        }
        public override AbstractTrade? decide(String s = "")
        {
            Market m = Market.getInstance();
            AbstractTrade? trade = core.decide(s);
            if (trade == null)
                return null;
            if (trade.getReceiver().getShare(trade.getTicker()) == 0)
                return null;
            float cost = trade.getReceiver().getCost(trade.getTicker());
            float current = trade.getReceiver().getShare(trade.getTicker())
                * m.getVal(trade.getTicker(), m.getPrevDate(m.getDate()));
            if (reverse)
            {
                if (current - cost > val)
                    return null;
                return trade;
            }
            if (current - cost < val)
                return null;
            return trade;
        }

        public override string describe()
        {
            String ret = core.describe();
            ret += "When value is ";
            ret += (reverse) ? "below " : "above ";
            ret += val.ToString() + " of cost basis\n";
            return ret;
        }
    }
}
