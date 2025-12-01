using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal class SharesDetail : AbstractStrategyDetail
    {
        int shares;
        public SharesDetail(IStrategy s, int n) : base(s)
        {
            shares = n;
        }

        public override AbstractTrade? decide(String s = "")
        {
            Market m = Market.getInstance();
            AbstractTrade? trade = core.decide(s);
            if (trade == null)
                return null;
            trade.setShares(shares);
            if (shares == 0)
            {
                int temp = (int)Math.Floor(trade.getMaximum()
                    / m.getVal(trade.getTicker(), m.getPrevDate(m.getDate())));
                if (temp == 0)
                    return null;
                trade.setShares(temp);
            }
            return trade;
        }

        public override string describe()
        {
            return core.describe() + shares.ToString() + " shares\n";
        }
    }
}
