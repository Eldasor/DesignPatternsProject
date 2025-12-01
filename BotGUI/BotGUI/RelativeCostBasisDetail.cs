using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // like CostBasisDetail, but using relative value rather than absolute
    // for example, if the last known price is X% over the Y cost basis
    internal class RelativeCostBasisDetail : AbstractStrategyDetail
    {
        float per;
        bool reverse; // if below, not above
        public RelativeCostBasisDetail(IStrategy s, float v, bool b) : base(s)
        {
            per = v; // this CAN be >100% or <0%
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
                if ((current - cost) / cost > per)
                    return null;
                return trade;
            }
            if ((current - cost) / cost < per)
                return null;
            return trade;
        }

        public override string describe()
        {
            String ret = core.describe();
            ret += "When value is ";
            ret += (reverse) ? "below " : "above ";
            ret += (per * 100).ToString() + "% of cost basis\n";
            return ret;
        }
    }
}
