using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace BotGUI
{
    // ...coming back to this later, this could have been abstracted better
    // oh well! too late now!

    // builds the trade to have a "max relative value"
    // that is, it'll only trade below a certain % of cash on hand
    internal class MaxRelativeValueDetail : AbstractStrategyDetail
    {
        float value;
        public MaxRelativeValueDetail(IStrategy s, float m) : base(s)
        {
            value = m;
        }
        public override AbstractTrade? decide(String s = "")
        {
            AbstractTrade? trade = core.decide(s);
            if (trade == null)
                return null;
            trade.setMaximum(value * trade.getReceiver().getCash());
            return trade;
        }

        public override string describe()
        {
            return core.describe() + "Max value of " + (value * 100).ToString() + "% of cash\n";
        }
    }
}
