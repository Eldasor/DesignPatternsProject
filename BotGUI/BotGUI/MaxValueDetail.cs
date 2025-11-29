using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // builds the trade with a max absolute value
    // it will only trade below this absolute cash value
    internal class MaxValueDetail : AbstractStrategyDetail
    {
        float value;
        public MaxValueDetail(IStrategy s, float m) : base(s)
        {
            value = m;
        }
        public override AbstractTrade? decide(String s = "")
        {
            AbstractTrade? trade = core.decide(s);
            if (trade == null)
                return null;
            trade.setMaximum(value);
            return trade;
        }
        public override string describe()
        {
            return core.describe() + "Max value of " + value.ToString() + "\n";
        }
    }
}
