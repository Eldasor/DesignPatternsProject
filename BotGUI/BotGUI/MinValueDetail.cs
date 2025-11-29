using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    internal class MinValueDetail : AbstractStrategyDetail
    {
        float value;
        public MinValueDetail(IStrategy s, float m) : base(s) {
            value = m;
        }
        public override AbstractTrade? decide(String s = "")
        {
            AbstractTrade? trade = core.decide(s);
            if (trade == null)
                return null;
            trade.setMinimum(value);
            return trade;
        }
        public override string describe()
        {
            return core.describe() + "Min value of " + value.ToString() + "\n";
        }
    }
}
