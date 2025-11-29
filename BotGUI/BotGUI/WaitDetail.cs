using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotGUI
{
    // this decides if a strategy should "wait" before executing again
    // this is so a stock doesn't repeatedly pass a decorated strategy day after day
    // should be the "almost-topmost" element of decoration
    // this strategy can also implement a "wait before turning on" by setting
    // the wait time to 0 and then offsetting the initial wait to negative
    internal class WaitDetail : AbstractStrategyDetail
    {
        private int wait;
        private int timeWaited;
        private int tt;
        public WaitDetail(IStrategy s, int w, int t = 0) : base(s)
        {
            wait = w;
            timeWaited = wait - t;
            tt = t;
        }
        public override AbstractTrade? decide(String s = "")
        {
            AbstractTrade? trade = core.decide(s);
            if (trade == null)
                return null;
            if (wait != timeWaited)
            {
                timeWaited++;
                return null;
            }
            timeWaited = 0;
            return trade;
        }

        public override string describe()
        {
            String ret = core.describe() + "Wait " + wait.ToString() + " between executions\n";
            if (tt != 0)
                ret += "Pause " + tt.ToString() + " before first execute\n";
            return ret;
        }
    }
}
